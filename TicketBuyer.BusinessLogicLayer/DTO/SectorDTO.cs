using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Enums;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class SectorDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public SectorType Type { get; set; }

        public int Limit { get; set; }

        public bool IsLimitReached { get; set; }

        public IList<SeatingDTO> Seatings { get; set; }
    }
}