using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Seating
    {
        [Key]
        public int Id { get; set; }

        public int SectorId { get; set; }

        public int Row { get; set; }

        public int Seat { get; set; }

        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
