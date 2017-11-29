using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface ITicketService
    {
        IList<Ticket> GetTickets(int orderId);

        void AddTickets(IList<TicketDTO> tickets);

        void RemoveTickets(IList<Ticket> ticketDtos);

    }
}