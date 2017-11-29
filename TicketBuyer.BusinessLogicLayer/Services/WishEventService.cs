using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsWishEventExist(int userId, int eventId)
        {
            return _unitOfWork.WishEventRepository.Find(x => x.UserId == userId && x.EventId == eventId).Any();
        }

        public IList<Event> GetWishEvents(int userId)
        {
            var wishEvents = _unitOfWork.WishEventRepository.Find(x => x.UserId == userId);

            return wishEvents.Select(x => x.Event).ToList();
        }

        public void AddWishEvent(int userId, int eventId)
        {
            if (!_unitOfWork.UserRepository.Find(x => x.Id == userId).Any())
            {
                throw new Exception();
            }

            if (!_unitOfWork.EventRepository.Find(x => x.Id == eventId).Any())
            {
                throw new Exception();
            }

            var wishEvent = new WishEvent
            {
                UserId = userId,
                EventId = eventId
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