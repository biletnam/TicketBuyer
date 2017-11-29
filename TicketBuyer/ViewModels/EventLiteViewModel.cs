using System;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.ViewModels
{
    public class EventLiteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public EventType Type { get; set; }
    }
}