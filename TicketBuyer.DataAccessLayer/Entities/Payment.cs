using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int PaymentTypeId { get; set; }

        public int? CancellationId { get; set; }

        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }

        public Order Order { get; set; }

        public Cancellation Cancellation { get; set; }
    }
}
