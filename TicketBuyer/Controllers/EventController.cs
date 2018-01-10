using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly IPlaceService _placeService;
        private readonly ITypeService _typeService;

        public EventController(IEventService eventService, IPlaceService placeService, ITypeService typeService)
        {
            _eventService = eventService;
            _placeService = placeService;
            _typeService = typeService;
        }

        [HttpGet("GetEvents")]
        public IActionResult GetEvents(int? type, int? status, DateTime? startDate, DateTime? endDate, int? placeId)
        {
            var events = _eventService.GetEvents(type, status, startDate, endDate, placeId);

            return CreateSuccessRequestResult(data: events.Select(x => new EventLiteViewModel
            {
                Id = x.Id,
                Name = x.Name,
                TypeId = x.TypeId,
                DateTime = x.DateTime,
                StatusId = x.StatusId,
                Place = new PlaceLiteViewModel { Id = x.PlaceId, Name = x.Place.Name, Address = x.Place.Address},
                EventPhotos = x.EventPhotos?.Select(y => $"/images/events/{y.Photo}").ToList()
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
                Types = _typeService.GetEventTypes(),
                Statuses = _typeService.GetEventStatuses()
            };

            return CreateSuccessRequestResult(data: viewModel);
        }

        [Authorize]
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
                TypeId = eventEntity.TypeId,
                StatusId = eventEntity.StatusId,
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
                },
                EventPhotos = eventEntity.EventPhotos?.Select(x => $"/images/events/{x.Photo}").ToList()
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
                TypeId = eventViewModel.TypeId,
                PlaceId = eventViewModel.PlaceId
            });

            return CreateSuccessRequestResult();
        }
    }
}
