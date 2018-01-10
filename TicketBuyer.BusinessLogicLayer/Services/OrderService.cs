using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITicketService _ticketService;

        public OrderService(IUnitOfWork unitOfWork, ITicketService ticketService)
        {
            _unitOfWork = unitOfWork;
            _ticketService = ticketService;
        }

        public IList<Order> GetOrders(int userId)
        {
            var orders = _unitOfWork.OrderRepository.Find(x => x.UserId == userId).ToList();
            orders.ForEach(x => { x.Tickets = _ticketService.GetTickets(x.Id); });

            return orders.ToList();
        }

        public void CreateOrder(Order order)
        {
            if (!_unitOfWork.UserRepository.Find(x => x.Id == order.UserId).Any())
            {
                throw new Exception();
            }


            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.SaveChanges();

           // _ticketService.AddTickets(order.Tickets.ToList());
        }

        public void CancelOrder(int orderId)
        {
            var order = _unitOfWork.OrderRepository.Find(x => x.Id == orderId).FirstOrDefault();

            if (order == null)
            {
                throw new Exception();
            }

            //order.Status = OrderStatus.Canceled;
            _ticketService.RemoveTickets(order.Tickets.ToList());
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.SaveChanges();
        }

        //public void PayForOrder(int orderId)
        //{

        //}
    }
}