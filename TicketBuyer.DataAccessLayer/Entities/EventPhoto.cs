using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class EventPhoto
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        public string Photo { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
