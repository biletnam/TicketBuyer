using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }
        
        public int AuthId { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("AuthId")]
        public Auth Auth { get; set; }

        public ICollection<EventComment> EventComments { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<WishEvent> WishEvents { get; set; }

        public ICollection<UserPreference> UserPreferences { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
