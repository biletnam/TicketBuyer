using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IEventCommentService
    {
        IList<EventCommentDTO> GetComments(int eventId);

        void AddComment(EventCommentDTO eventCommentDto);
    }
}