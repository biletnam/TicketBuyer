using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
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

        public IList<EventCommentDTO> GetComments(int eventId)
        {
            return _unitOfWork.EventCommentRepository.Find(x => x.EventId == eventId).Select(x => new EventCommentDTO
            {
                Id = x.Id,
                User = new UserLiteDTO {Id = x.User.Id, Username = x.User.Username},
                Comment = x.Comment,
                DateTime = x.DateTime
            }).ToList();
        }

        public void AddComment(EventCommentDTO eventCommentDto)
        {
            if (!_unitOfWork.EventRepository.Find(x => x.Id == eventCommentDto.EventId).Any())
            {
                throw new Exception();
            }

            if (!_unitOfWork.UserRepository.Find(x => x.Id == eventCommentDto.UserId).Any())
            {
                throw new Exception();
            }

            var eventComment = new EventComment
            {
                UserId = eventCommentDto.UserId,
                EventId = eventCommentDto.EventId,
                DateTime = DateTime.Now,
                Comment = eventCommentDto.Comment
            };

            _unitOfWork.EventCommentRepository.Add(eventComment);
            _unitOfWork.SaveChanges();
        }
    }
}