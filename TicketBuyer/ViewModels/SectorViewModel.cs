using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.ViewModels
{
    public class SectorViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Limit { get; set; }

        public int TypeId { get; set; }

        public IList<SeatingLiteViewModel> Seatings { get; set; }
    }
}
