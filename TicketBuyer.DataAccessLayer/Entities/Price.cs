using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Price
    {
        [Key]
        public int Id { get; set; }

        public int EventId { get; set; }

        public int SectorId { get; set; }

        public float EventPrice { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }

        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }
    }
}
