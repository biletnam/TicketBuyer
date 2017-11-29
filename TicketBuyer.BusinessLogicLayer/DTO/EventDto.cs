using System.Collections.Generic;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class EventDTO : EventLiteDTO
    {
        public string Information { get; set; }

        public int PlaceId { get; set; }

        public PlaceLiteDTO Place { get; set; }

        public IList<EventCommentDTO> EventComments { get; set; }

       // public ICollection<EventPhotoDTO> EventPhotos { get; set; }
    }
}