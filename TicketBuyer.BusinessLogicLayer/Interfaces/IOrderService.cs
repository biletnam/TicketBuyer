using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IOrderService
    {
        IList<OrderDTO> GetOrders(int userId);

        void CreateOrder(OrderDTO orderDto);

        void CancelOrder(int orderId);

        //void PayForOrder(OrderDTO orderDto);
    }
}