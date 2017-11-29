using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IWishEventService
    {
        IList<WishEventDTO> GetWishEvents(int userId);

        void AddWishEvent(WishEventDTO wishEventDto);

        void RemoveWishEvent(int wishEventId);
    }
}