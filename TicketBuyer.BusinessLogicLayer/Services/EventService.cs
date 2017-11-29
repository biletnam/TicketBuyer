using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
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

        public EventDTO GetEvent(int id)
        {
            var eventEntity = GetExistingEvent(id);

            var comments = _eventCommentService.GetComments(id);
            var place = _placeService.GetPlaceLite(eventEntity.PlaceId);

            return new EventDTO
            {
                Id = eventEntity.Id,
                Name = eventEntity.Name,
                Information = eventEntity.Information,
                DateTime = eventEntity.DateTime,
                Type = eventEntity.Type,
                Place = place,
                EventComments = comments
            };
        }

        public IList<EventLiteDTO> GetEvents()
        {
            var events = _unitOfWork.EventRepository.GetAll();

            return Map(events);
        }

        public IList<EventLiteDTO> GetEventsByType(EventType type)
        {
            var events = _unitOfWork.EventRepository.Find(x => x.Type == type);

            return Map(events);
        }

        public IList<EventLiteDTO> GetEventsByDateTimeRange(DateTime start, DateTime end)
        {
            var events = _unitOfWork.EventRepository.Find(x => x.DateTime >= start && x.DateTime <= end);

            return Map(events);
        }

        public IList<EventLiteDTO> GetEventsByPlace(int placeId)
        {
            var events = _unitOfWork.EventRepository.Find(x => x.PlaceId == placeId);

            return Map(events);
        }

        public void AddEvent(EventDTO EventDTO)
        {
            var alreadyAdded = _unitOfWork.EventRepository.Find(x =>
                x.Name == EventDTO.Name && x.DateTime == EventDTO.DateTime &&
                x.Type == EventDTO.Type).FirstOrDefault();

            if (alreadyAdded != null)
            {
                throw new Exception();
            }

            var eventEntity = new Event
            {
                Name = EventDTO.Information,
                Information = EventDTO.Information,
                DateTime = EventDTO.DateTime,
                Type = EventDTO.Type,
                PlaceId = EventDTO.PlaceId
            };

            _unitOfWork.EventRepository.Add(eventEntity);
            _unitOfWork.SaveChanges();
        }

        public void UpdateEvent(EventDTO EventDTO)
        {
            var eventEntity = GetExistingEvent(EventDTO.Id);

            eventEntity.Name = EventDTO.Information;
            eventEntity.Information = EventDTO.Information;
            eventEntity.DateTime = EventDTO.DateTime;
            eventEntity.Type = EventDTO.Type;
            eventEntity.PlaceId = EventDTO.PlaceId;

            _unitOfWork.EventRepository.Update(eventEntity);
            _unitOfWork.SaveChanges();
        }

        public void RemoveEvent(EventDTO EventDTO)
        {
            var eventEntity = _unitOfWork.EventRepository.Find(x => x.Id == EventDTO.Id).FirstOrDefault();

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

        private IList<EventLiteDTO> Map(IEnumerable<Event> events)
        {
            return events.Select(x => new EventLiteDTO
            {
                Id = x.Id,
                Name = x.Name,
                DateTime = x.DateTime,
                Type = x.Type
            }).ToList();
        }
    }
}