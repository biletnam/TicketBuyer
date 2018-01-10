using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class UserPreference
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public int EventTypeId { get; set; }

        [ForeignKey("EventTypeId")]
        public EventType EventType { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
