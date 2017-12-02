using Microsoft.AspNetCore.Mvc;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    public class OrderController : BaseController
    {
        [HttpPost("Pay")]
        public IActionResult Pay(int orderId)
        {
            return CreateSuccessRequestResult();
        }

        [HttpPost("Cancel")]
        public IActionResult Cancel(int orderId)
        {
            return CreateSuccessRequestResult();
        }
    }
}
