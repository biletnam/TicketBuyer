using System;
using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IEventService
    {
        Event GetEvent(int id);

        IList<Event> GetEvents(EventType? type, EventStatus? status, DateTime? startDate, DateTime? endDate, int? placeId);

        void AddEvent(Event eventEntity);

        void UpdateEvent(Event eventEntity);

        void RemoveEvent(int eventId);
    }
}