using System;
using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IEventService
    {
        EventDTO GetEvent(int id);

        IList<EventLiteDTO> GetEvents();

        IList<EventLiteDTO> GetEventsByType(EventType type);

        IList<EventLiteDTO> GetEventsByDateTimeRange(DateTime start, DateTime end);

        IList<EventLiteDTO> GetEventsByPlace(int placeId);

        void AddEvent(EventDTO eventViewModel);

        void UpdateEvent(EventDTO eventViewModel);

        void RemoveEvent(EventDTO eventViewModel);
    }
}