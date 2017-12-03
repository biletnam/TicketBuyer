using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Enums;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventCommentService _eventCommentService;
        private readonly IPlaceService _placeService;

        public EventService(IUnitOfWork unitOfWork, IEventCommentService eventCommentService, IPlaceService placeService)
        {
            _unitOfWork = unitOfWork;
            _eventCommentService = eventCommentService;
            _placeService = placeService;
        }

        public Event GetEvent(int id)
        {
            var eventEntity = GetExistingEvent(id);

            eventEntity.EventComments = _eventCommentService.GetComments(id);
            eventEntity.Place = _placeService.GetPlaceLite(eventEntity.PlaceId);

            return eventEntity;
        }

        public IList<Event> GetEvents(EventType? type, EventStatus? status, DateTime? startDate, DateTime? endDate, int? placeId)
        {
            var data = _unitOfWork.EventRepository.GetAll();

            if (type.HasValue)
            {
                data = data.Where(x => x.Type == type);
            }

            if (status.HasValue)
            {
                data = data.Where(x => x.Status == status);
            }

            if (startDate.HasValue)
            {
                data = data.Where(x => x.DateTime >= startDate);
            }

            if (endDate.HasValue)
            {
                data = data.Where(x => x.DateTime <= endDate);
            }

            if (placeId.HasValue)
            {
                data = data.Where(x => x.PlaceId == placeId);
            }

            data.ToList().ForEach(x =>
            {
                x.Place = _placeService.GetPlaceLite(x.PlaceId);
            });

            return data.ToList();
        }
        
        public void AddEvent(Event eventEntity)
        {
            var alreadyAdded = _unitOfWork.EventRepository.Find(x =>
                x.Name == eventEntity.Name && x.DateTime == eventEntity.DateTime &&
                x.Type == eventEntity.Type).FirstOrDefault();

            if (alreadyAdded != null)
            {
                throw new Exception();
            }

            _unitOfWork.EventRepository.Add(eventEntity);
            _unitOfWork.SaveChanges();
        }

        public void UpdateEvent(Event eventEnity)
        {
            var existingEvent = GetExistingEvent(eventEnity.Id);

            existingEvent.Name = eventEnity.Information;
            existingEvent.Information = eventEnity.Information;
            existingEvent.DateTime = eventEnity.DateTime;
            existingEvent.Type = eventEnity.Type;
            existingEvent.PlaceId = eventEnity.PlaceId;

            _unitOfWork.EventRepository.Update(existingEvent);
            _unitOfWork.SaveChanges();
        }

        public void RemoveEvent(int eventId)
        {
            var eventEntity = _unitOfWork.EventRepository.Find(x => x.Id == eventId).FirstOrDefault();

            if (eventEntity == null)
            {
                throw new Exception();
            }

            _unitOfWork.EventRepository.Remove(eventEntity);
            _unitOfWork.SaveChanges();
        }

        private Event GetExistingEvent(int id)
        {
            var eventEntity = _unitOfWork.EventRepository.Find(x => x.Id == id).FirstOrDefault();

            if (eventEntity == null)
            {
                throw new Exception();
            }

            return eventEntity;
        }
    }
}