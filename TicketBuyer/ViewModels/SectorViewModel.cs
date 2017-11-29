using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.ViewModels
{
    public class SectorViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public SectorType Type { get; set; }

        public int Limit { get; set; }

       // public ICollection<Seating> Seatings { get; set; }
    }
}