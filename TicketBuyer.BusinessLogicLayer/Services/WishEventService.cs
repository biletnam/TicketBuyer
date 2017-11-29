using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class WishEventService : IWishEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WishEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<WishEventDTO> GetWishEvents(int userId)
        {
            var wishEvents = _unitOfWork.WishEventRepository.Find(x => x.UserId == userId);

            return wishEvents.Select(x => new WishEventDTO
            {
                Id = x.Id,
                Event = new EventLiteDTO
                {
                    Id = x.Event.Id,
                    Name = x.Event.Name,
                    DateTime = x.Event.DateTime,
                    Type = x.Event.Type
                },
            }).ToList();
        }

        public void AddWishEvent(WishEventDTO wishEventDto)
        {
            if (!_unitOfWork.UserRepository.Find(x => x.Id == wishEventDto.UserId).Any())
            {
                throw new Exception();
            }

            if (!_unitOfWork.EventRepository.Find(x => x.Id == wishEventDto.EventId).Any())
            {
                throw new Exception();
            }

            var wishEvent = new WishEvent
            {
                UserId = wishEventDto.UserId,
                EventId = wishEventDto.EventId
            };

            _unitOfWork.WishEventRepository.Add(wishEvent);
            _unitOfWork.SaveChanges();
        }

        public void RemoveWishEvent(int wishEventId)
        {
            var wishEvent = _unitOfWork.WishEventRepository.Find(x => x.Id == wishEventId).FirstOrDefault();

            if (wishEvent == null)
            {
                throw new Exception();
            }

            _unitOfWork.WishEventRepository.Remove(wishEvent);
            _unitOfWork.SaveChanges();
        }
    }
}