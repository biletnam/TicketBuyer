using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCurrentUserInfo()
        {
            var user = _userService.GetUser(User.Identity.Name);

            return CreateSuccessRequestResult(data: new UserViewModel
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AuthViewModel authViewModel)
        {
            if (_userService.IsUserExist(authViewModel.Username, authViewModel.Email))
                return CreateFailedRequestResult("A user with such username/email is already exist");

            _userService.RegisterUser(authViewModel.Username, authViewModel.Email, authViewModel.Password);

            return CreateSuccessRequestResult("User is registered and now you can sign-in");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthViewModel authViewModel)
        {
            var user = _userService.GetUserForLogin(authViewModel.Email, authViewModel.Password);

            if (user == null) return CreateFailedRequestResult("Email or password is invalid");

            var loggedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) },
                CookieAuthenticationDefaults.AuthenticationScheme));
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, loggedUser);

            return CreateSuccessRequestResult();
        }
    }
}
