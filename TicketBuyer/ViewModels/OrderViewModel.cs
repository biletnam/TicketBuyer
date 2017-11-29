using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public OrderStatus Status { get; set; }

        public int? PaymentId { get; set; }

        //public PaymentDTO Payment { get; set; }

        public IList<TicketViewModel> Tickets { get; set; }
    }
}
