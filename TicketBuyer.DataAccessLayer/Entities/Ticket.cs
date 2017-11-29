using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int EventId { get; set; }

        public int SectorId { get; set; }

        public int? SeatingId { get; set; }

        public float Price { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }

        [ForeignKey("SeatingId")]
        public Seating Seating { get; set; }
    }
}
