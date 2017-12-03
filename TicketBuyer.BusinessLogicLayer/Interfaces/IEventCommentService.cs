using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IEventCommentService
    {
        IList<EventComment> GetComments(int eventId);

        void AddComment(EventComment eventComment);
    }
}