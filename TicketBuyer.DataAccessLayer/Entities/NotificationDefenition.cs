using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class NotificationDefenition
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
