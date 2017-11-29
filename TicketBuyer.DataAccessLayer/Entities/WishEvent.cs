using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class WishEvent
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
