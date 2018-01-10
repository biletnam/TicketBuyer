using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class EventType
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<UserPreference> UserPreferences { get; set; }
    }
}
