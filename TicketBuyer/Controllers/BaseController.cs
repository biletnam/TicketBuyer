using Microsoft.AspNetCore.Mvc;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    public class BaseController : Controller
    {
        protected virtual IActionResult CreateFailedRequestResult(string message = null)
        {
            return new JsonResult(new RequestResult
            {
                State = RequestState.Failed,
                Message = message
            });
        }

        protected virtual IActionResult CreateSuccessRequestResult(string message = null, object data = null)
        {
            return new JsonResult(new RequestResult
            {
                State = RequestState.Success,
                Message = message,
                Data = data
            });
        }
    }
}
