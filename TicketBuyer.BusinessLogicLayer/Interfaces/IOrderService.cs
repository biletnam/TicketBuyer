using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        IList<Order> GetOrders(int userId);

        void CreateOrder(Order orderDto);

        void CancelOrder(int orderId);

        //void PayForOrder(OrderDTO orderDto);
    }
}