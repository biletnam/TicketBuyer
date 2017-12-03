using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class EventCommentService : IEventCommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventCommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<EventComment> GetComments(int eventId)
        {
            return _unitOfWork.EventCommentRepository.Find(x => x.EventId == eventId).ToList();
        }

        public void AddComment(EventComment eventComment)
        {
            if (!_unitOfWork.EventRepository.Find(x => x.Id == eventComment.EventId).Any())
            {
                throw new Exception();
            }

            if (!_unitOfWork.UserRepository.Find(x => x.Id == eventComment.UserId).Any())
            {
                throw new Exception();
            }

            _unitOfWork.EventCommentRepository.Add(eventComment);
            _unitOfWork.SaveChanges();
        }
    }
}