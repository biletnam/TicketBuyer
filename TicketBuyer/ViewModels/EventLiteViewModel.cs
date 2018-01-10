using System;
using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.ViewModels
{
    public class EventLiteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateTime { get; set; }

        public int TypeId { get; set; }

        public int StatusId { get; set; }

        public int PlaceId { get; set; }

        public PlaceLiteViewModel Place { get; set; }

        public IList<string> EventPhotos { get; set; }
    }
}
