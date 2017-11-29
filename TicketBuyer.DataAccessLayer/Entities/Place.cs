using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Information { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<Sector> Sectors { get; set; }

        public ICollection<PlacePhoto> PlacePhotos { get; set; }
    }
}
