using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.ViewModels
{
    public class EventCommentViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public int EventId { get; set; }

        public DateTime DateTime { get; set; }
    }
}
