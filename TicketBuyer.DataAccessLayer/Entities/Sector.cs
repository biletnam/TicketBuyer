using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Sector
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int PlaceId { get; set; }

        public SectorType Type { get; set; }

        public int Limit { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }

        public ICollection<Seating> Seatings { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Price> Prices { get; set; }
    }
}
