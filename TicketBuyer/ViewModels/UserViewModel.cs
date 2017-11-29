using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
