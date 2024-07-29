using LibraryServices.Interfaces;
using LibraryUtilities;
using LibraryViewModels.DTO.Request;
using LibraryViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = $"{RoleEnum.Librarian}, {RoleEnum.Public}")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpPost]
        [Route("GetUserId/{email}")]
        public async Task<ActionResult> GetUserId(string email)
        {
            return Json(await this._authService.GetUserId(email));
        }

        [HttpPost]
        [Route("HasRole/{id}/{role}")]
        public async Task<ActionResult> HasRole(string id, string role)
        {
            return Json(await this._authService.HasRole(id, role));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(LibraryRegistrationRequest registrationRequest)
        {
            return Json(await this._authService.Register(registrationRequest));
        }
        
        [HttpPost]
        [Route("RegisterPublicRole/{id}")]
        public async Task<ActionResult> RegisterPublicRole(string id)
        {
            return Json(await this._authService.RegisterUserRole(id, RoleEnum.Public));
        }

        [HttpPost]
        [Route("RegisterLibrarianRole/{id}")]
        public async Task<ActionResult> RegisterLibrarianRole(string id)
        {
            return Json(await this._authService.RegisterUserRole(id, RoleEnum.Librarian));
        }

    }
}
