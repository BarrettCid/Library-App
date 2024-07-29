using AutoMapper;
using LibraryModel.Context;
using LibraryModel.Model;
using LibraryServices.Interfaces;
using LibraryUtilities;
using LibraryViewModels.DTO.Request;
using LibraryViewModels.DTO.Response;
using LibraryViewModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace LibraryServices.Services
{
    public class AuthService : IAuthService
    {
        private LibraryDbContext _libraryDbContext;
        private UserManager<LibraryUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<LibraryUser> _hasher;
        private IMapper _mapper;
        public AuthService(LibraryDbContext libraryDbContext, UserManager<LibraryUser> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper, IPasswordHasher<LibraryUser> hasher)
        {
            this._libraryDbContext = libraryDbContext;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._hasher = hasher;
        }

        public async Task<string> GetUserId(string emailAddress)
        {
            return await this._libraryDbContext.Users.Where(u => u.Email == emailAddress).Select(u => u.Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Register(LibraryRegistrationRequest registrationRequest)
        {
            try
            {
                LibraryUser user = new LibraryUser();
                user.UserName = registrationRequest.Email;
                user.Email = registrationRequest.Email;
                user.NormalizedEmail = registrationRequest.Email.ToUpper();
                user.NormalizedUserName = registrationRequest.Email.ToUpper();
                user.FirstName = registrationRequest.FirstName;
                user.LastName = registrationRequest.LastName;
                user.PasswordHash = this._hasher.HashPassword(user, registrationRequest.Password!);
                this._libraryDbContext.Add(user);
                await this._libraryDbContext.SaveChangesAsync();
                await this.RegisterUserRole(user.Id, registrationRequest.Role!);
                return true;
            }
            catch (Exception ex)
            {
                //remove account if the rest of the process fails after registration
                if(this._libraryDbContext.Users.Any(x => x.Email == registrationRequest.Email))
                {
                    var user = await this._libraryDbContext.Users.Where(x => x.Email == registrationRequest.Email).FirstOrDefaultAsync();
                    this._libraryDbContext.Users.Remove(user!);
                    await this._libraryDbContext.SaveChangesAsync();
                }
                throw new Exception("An error occured during registration. Please try again. " + ex.Message);
            }
        }

        public async Task<bool> HasRole(string id, string role)
        {
            try
            {
                var currentUser = await this._userManager.FindByIdAsync(id);
                if (currentUser == null)
                {
                    throw new Exception("Unable to find user to check for a role");
                }
                var roles = await this._roleManager.Roles.ToListAsync();
                var roleEntity = await this._roleManager.Roles.Where(r => r.Name == role).FirstOrDefaultAsync();
                var result = await this._userManager.IsInRoleAsync(currentUser, roleEntity!.NormalizedName!);
                return result;
            }
            catch (Exception ex)
            {  
                throw new Exception(ex.Message);
            }
        }

        public async Task<LibraryUserVM> RegisterUserRole(string id, string role)
        {
            var currentUser = await this._userManager.FindByIdAsync(id);
            if (currentUser == null)
            {
                throw new Exception("Unable to find a user to give access.");
            }
            var roleEntity = await this._roleManager.Roles.Where(r => r.Name == role).FirstOrDefaultAsync();
            var roleResult = await this._userManager.AddToRoleAsync(currentUser!, roleEntity!.NormalizedName!);
            return this._mapper.Map<LibraryUserVM>(currentUser);
        }
    }
}
