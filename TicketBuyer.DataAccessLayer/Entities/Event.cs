using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }

        public DateTime DateTime { get; set; }

        public EventType Type { get; set; }

        public EventStatus Status { get; set; }

        public int PlaceId { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }

        public ICollection<EventComment> EventComments { get; set; }

        public ICollection<WishEvent> WishEvents { get; set; }

        public ICollection<EventPhoto> EventPhotos { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}