using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IEventSectorsService
    {
        bool IsSectorLimitReached(int sectorId, int eventId);

      //  IList<SeatingDTO> GetSeatings(int sectorId, int eventId);
    }
}