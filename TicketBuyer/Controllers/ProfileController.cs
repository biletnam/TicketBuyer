using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Profile")]
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IWishEventService _wishEventService;

        public ProfileController(IUserService userService, IOrderService orderService, IWishEventService wishEventService)
        {
            _userService = userService;
            _orderService = orderService;
            _wishEventService = wishEventService;
        }

        [HttpGet]
        public IActionResult GetUserProfile(string username)
        {
            var user = _userService.GetUser(User.Identity.Name);
            var wishEvents = _wishEventService.GetWishEvents(user.Id);
            var orders = _orderService.GetOrders(user.Id);

            var userPageViewModel = new UserPageViewModel
            {
                User = new UserViewModel { Username = user.Username, Email = user.Email },
                WishEvents = wishEvents.Select(x => new EventLiteViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateTime = x.DateTime
                }).ToList(),
                Orders = orders.Select(x => new OrderViewModel
                {
                    Id = x.Id,
                    Status = x.Status,
                    Tickets = x.Tickets.Select(y => new TicketViewModel
                    {
                        Id = y.Id,
                        Event = new EventViewModel
                        {
                            Id = y.EventId,
                            DateTime = y.Event.DateTime,
                            Name = y.Event.Name,
                            Place = new PlaceViewModel { Address = y.Event.Place.Address, Name = y.Event.Place.Name },
                        },
                        Sector = new SectorViewModel { Title = y.Sector.Title },
                        //Seating
                    }).ToList()
                }).ToList()
            };

            return CreateSuccessRequestResult(data: userPageViewModel);
        }
    }
}
