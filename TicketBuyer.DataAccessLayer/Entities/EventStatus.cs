using System.Collections.Generic;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class EventStatus
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}