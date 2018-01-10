using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<Ticket> GetTickets(int orderId)
        {
            var tickets = _unitOfWork.TicketRepository.Find(x => x.OrderId == orderId);

            return tickets.ToList();
        }

        public void AddTickets(IList<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                AddTicket(ticket);
            }
        }

        public void RemoveTickets(IList<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                _unitOfWork.TicketRepository.Remove(ticket);
            }    
        }

        private void AddTicket(Ticket ticket)
        {
            _unitOfWork.TicketRepository.Add(ticket);
            _unitOfWork.SaveChanges();
        }
    }
}