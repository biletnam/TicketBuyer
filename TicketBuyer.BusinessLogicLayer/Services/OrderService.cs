using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Enums;
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

        public IList<OrderDTO> GetOrders(int userId)
        {
            var orders = _unitOfWork.OrderRepository.Find(x => x.UserId == userId);
            
            return orders.Select(x => new OrderDTO
            {
                Id = x.Id,
                Status = x.Status,
                Tickets = _ticketService.GetTickets(x.Id),
                Payment = x.PaymentId.HasValue ? new PaymentDTO { Id = x.PaymentId.Value, DateTime = x.Payment.DateTime } : null
            }).ToList();
        }

        public void CreateOrder(OrderDTO orderDto)
        {
            if (!_unitOfWork.UserRepository.Find(x => x.Id == orderDto.UserId).Any())
            {
                throw new Exception();
            }

            var order = new Order
            {
                UserId = orderDto.Id,
                Status = OrderStatus.Created
            };

            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.SaveChanges();

            _ticketService.AddTickets(orderDto.Tickets);
        }

        public void CancelOrder(int orderId)
        {
            var order = _unitOfWork.OrderRepository.Find(x => x.Id == orderId).FirstOrDefault();

            if (order == null)
            {
                throw new Exception();
            }

            order.Status = OrderStatus.Canceled;
            _ticketService.RemoveTickets(order.Tickets.ToList());
            _unitOfWork.OrderRepository.Update(order);
            _unitOfWork.SaveChanges();
        }

        //public void PayForOrder(int orderId)
        //{

        //}
    }
}