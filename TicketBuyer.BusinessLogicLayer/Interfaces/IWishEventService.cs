using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IWishEventService
    {
        bool IsWishEventExist(int userId, int eventId);

        IList<Event> GetWishEvents(int userId);

        void AddWishEvent(int userId, int eventId);

        void RemoveWishEvent(int wishEventId);
    }
}