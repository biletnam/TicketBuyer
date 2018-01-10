using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class EventSale
    {
        [Key]
        public int Id { get; set; }

        public int SaleId { get; set; }

        public int EventId { get; set; }

        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}