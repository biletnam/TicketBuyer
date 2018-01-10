using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class EventNews
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Article { get; set; }

        public DateTime DateTime { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
