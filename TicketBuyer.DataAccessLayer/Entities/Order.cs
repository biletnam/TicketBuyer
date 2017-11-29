using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public int? PaymentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("Id")]
        public Payment Payment { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
