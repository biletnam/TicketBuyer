using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int StatusId { get; set; }

        public int? PaymentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Payment Payment { get; set; }

        [ForeignKey("StatusId")]
        public OrderStatus Status { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<GiftCertificateOrder> GiftCertificateOrders { get; set; }

    }
}
