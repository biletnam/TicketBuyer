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
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetCurrentUserInfo()
        {
            var user = _userService.GetUser(User.Identity.Name);

            if (user == null) return CreateFailedRequestResult();

            return CreateSuccessRequestResult(data: new UserViewModel
            {
                Username = user.Username,
                //Email = user.Email,
                Role = user.RoleId
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AuthViewModel authViewModel)
        {
            if (_authService.IsUserExist(authViewModel.Username, authViewModel.Email))
                return CreateFailedRequestResult("A user with such username/email is already exist");

            _authService.RegisterUser(authViewModel.Username, authViewModel.Email, authViewModel.Password);

            return CreateSuccessRequestResult("User is registered and now you can sign-in");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthViewModel authViewModel)
        {
            var user = _authService.GetUserForLogin(authViewModel.Email, authViewModel.Password);

            if (user == null) return CreateFailedRequestResult("Email or password is invalid");

            var loggedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.Username) },
                CookieAuthenticationDefaults.AuthenticationScheme));
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, loggedUser);

            return CreateSuccessRequestResult();
        }
    }
}
