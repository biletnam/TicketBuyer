using System;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class EventCommentDTO
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int EventId { get; set; }

        public int UserId { get; set; }

        public UserLiteDTO User { get; set; }

        public DateTime DateTime { get; set; }
    }
}