using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return new JsonResult(new RequestResult
            {
                State = RequestState.Success,
                Data = new
                {
                    UserName = claimsIdentity.Name,
                    //Role = claimsIdentity.Claims.First(x => x.)
                }
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var user = new UserLiteDTO {Email = userViewModel.Email, Password = userViewModel.Password, Username = userViewModel.Username};

                _userService.AddUser(user);

                return new JsonResult(new RequestResult
                {
                    State = RequestState.Success,
                    Message = "User is registered and now you can sign-in"
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new RequestResult
                {
                    State = RequestState.Failed,
                    Message = e.Message
                });
            }
            
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserViewModel userViewModel)
        {
            var user = _userService.GetUserLite(userViewModel.Email, userViewModel.Password);

            if (user != null)
            {
                var loggedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] {new Claim(ClaimTypes.Name, user.Username)},
                    CookieAuthenticationDefaults.AuthenticationScheme));
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, loggedUser);

                return new JsonResult(new RequestResult
                {
                    State = RequestState.Success
                });
            }

            return new JsonResult(new RequestResult
            {
                State = RequestState.Failed,
                Message = "Email or password is invalid"
            });
        }
    }
}
