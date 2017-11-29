using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public Role Role { get; set; }

        public ICollection<EventComment> EventComments { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<WishEvent> WishEvents { get; set; }
    }
}
