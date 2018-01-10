using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }

        public DateTime DateTime { get; set; }

        public int PlaceId { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }

        [ForeignKey("TypeId")]
        public EventType Type { get; set; }

        [ForeignKey("StatusId")]
        public EventStatus Status { get; set; }

        public ICollection<EventComment> EventComments { get; set; }

        public ICollection<WishEvent> WishEvents { get; set; }

        public ICollection<EventPhoto> EventPhotos { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<EventNews> EventNews { get; set; }

        public ICollection<EventSale> EventSales { get; set; }
    }
}