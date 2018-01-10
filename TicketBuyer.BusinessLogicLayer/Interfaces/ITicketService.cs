using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface ITicketService
    {
        IList<Ticket> GetTickets(int orderId);

        void AddTickets(IList<Ticket> tickets);

        void RemoveTickets(IList<Ticket> ticketDtos);

    }
}