using LibraryViewModels.DTO.Request;
using LibraryViewModels.DTO.Response;
using LibraryViewModels.ViewModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetUserId(string emailAddress);
        Task<bool> HasRole(string id, string role); 
        Task<bool> Register(LibraryRegistrationRequest registrationRequest);
        Task<LibraryUserVM> RegisterUserRole(string id, string role);
    }
}
