namespace TicketBuyer.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        //[ForeignKey("RoleId")]
        //public Role Role { get; set; }

        //[ForeignKey("Id")]
        //public Auth Auth { get; set; }

        //public ICollection<EventComment> EventComments { get; set; }

        //public ICollection<Order> Orders { get; set; }

        //public ICollection<WishEvent> WishEvents { get; set; }
    }
}
