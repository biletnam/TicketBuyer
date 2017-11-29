using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public OrderStatus Status { get; set; }

        public int? PaymentId { get; set; }

        public PaymentDTO Payment { get; set; }

        public IList<TicketDTO> Tickets { get; set; }
    }
}