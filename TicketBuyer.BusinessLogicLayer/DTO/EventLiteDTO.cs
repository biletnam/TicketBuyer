using System;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class EventLiteDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public EventType Type { get; set; }
    }
}