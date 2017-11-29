using System.Collections.Generic;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class PlaceDTO : PlaceLiteDTO
    {
        public string Information { get; set; }

        public IList<EventLiteDTO> Events { get; set; }

        public IList<SectorDTO> Sectors { get; set; }

        //public ICollection<PlacePhoto> PlacePhotos { get; set; }
    }
}