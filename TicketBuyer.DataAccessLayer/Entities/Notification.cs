using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public int NotificationDefenitionId { get; set; }

        public int UserId { get; set; }

        public DateTime DateTime { get; set; }

        public bool IsSent { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("NotificationDefenitionId")]
        public NotificationDefenition NotificationDefenition { get; set; }
    }
}