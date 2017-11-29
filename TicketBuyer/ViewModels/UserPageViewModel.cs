using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.ViewModels
{
    public class UserPageViewModel
    {
        public UserViewModel User { get; set; }

        public IList<EventLiteViewModel> WishEvents { get; set; }

        public IList<OrderViewModel> Orders { get; set; }
    }
}
