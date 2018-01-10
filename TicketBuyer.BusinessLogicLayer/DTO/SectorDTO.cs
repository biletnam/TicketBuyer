using System.Collections.Generic;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class SectorDTO
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Title { get; set; }

        public int Limit { get; set; }

        public IList<SeatingDTO> Seatings { get; set; }
    }
}