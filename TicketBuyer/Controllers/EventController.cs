using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Enums;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly IPlaceService _placeService;

        public EventController(IEventService eventService, IPlaceService placeService)
        {
            _eventService = eventService;
            _placeService = placeService;
        }

        [HttpGet("GetEvents")]
        public IActionResult GetEvents(EventType? type, EventStatus? status, DateTime? startDate, DateTime? endDate, int? placeId)
        {
            var events = _eventService.GetEvents(type, status, startDate, endDate, placeId);

            return CreateSuccessRequestResult(data: events.Select(x => new EventLiteViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                DateTime = x.DateTime,
                Status = x.Status,
                Place = new PlaceLiteViewModel { Id = x.PlaceId, Name = x.Place.Name, Address = x.Place.Address}
            }));
        }

        [HttpGet("GetEventFiltersData")]
        public IActionResult GetEventFiltersData()
        {
            var viewModel = new EventFiltersDataViewModel
            {
                Places = _placeService.GetPlaces().Select(x => new PlaceLiteViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList(),
                Types = Enum.GetValues(typeof(EventType)).Cast<EventType>()
                    .ToDictionary(x => (int) x, x => x.ToString()),
                Statuses = Enum.GetValues(typeof(EventStatus)).Cast<EventStatus>()
                    .ToDictionary(x => (int) x, x => x.ToString())
            };

            return CreateSuccessRequestResult(data: viewModel);
        }

        [HttpGet("GetEvent")]
        public IActionResult GetEvent(int eventId)
        {
            var eventEntity = _eventService.GetEvent(eventId);

            return CreateSuccessRequestResult(data: new EventViewModel
            {
                Id = eventEntity.Id,
                Name = eventEntity.Name,
                Information = eventEntity.Information,
                DateTime = eventEntity.DateTime,
                Type = eventEntity.Type,
                Status = eventEntity.Status,
                EventComments = eventEntity.EventComments.Select(x => new EventCommentViewModel
                {
                    Id = x.Id,
                    DateTime = x.DateTime,
                    Username = x.User.Username,
                    Comment = x.Comment
                }).ToList(),
                Place = new PlaceLiteViewModel
                {
                    Id = eventEntity.PlaceId,
                    Name = eventEntity.Place.Name,
                    Address = eventEntity.Place.Address
                }
            });
        }

        [HttpPost("AddEvent")]
        public IActionResult AddEvent([FromBody] EventViewModel eventViewModel)
        {
            _eventService.AddEvent(new Event
            {
                Name = eventViewModel.Name,
                Information = eventViewModel.Information,
                DateTime = eventViewModel.DateTime,
                Type = eventViewModel.Type,
                PlaceId = eventViewModel.PlaceId
            });
            return CreateSuccessRequestResult();
        }
    }
}
