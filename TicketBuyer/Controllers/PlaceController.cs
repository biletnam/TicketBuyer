using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.ViewModels;

namespace TicketBuyer.Controllers
{
    [Produces("application/json")]
    [Route("api/Place")]
    public class PlaceController : BaseController
    {
        private readonly IPlaceService _placeService;
        private readonly ITypeService _typeService;

        public PlaceController(IPlaceService placeService, ITypeService typeService)
        {
            _placeService = placeService;
            _typeService = typeService;
        }

        [HttpGet("GetPlaces")]
        public IActionResult GetPlaces()
        {
            var places = _placeService.GetPlaces();

            return CreateSuccessRequestResult(data: places.Select(x => new PlaceLiteViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                PlacePhotos = x.PlacePhotos.Select(y => $"/images/places/{y.Photo}").ToList()
            }));
        }

        [HttpGet("GetPlace")]
        public IActionResult GetPlace(int placeId)
        {
            var place = _placeService.GetPlace(placeId);

            return CreateSuccessRequestResult(data: new PlaceViewModel
            {
                Id = place.Id,
                Name = place.Name,
                Address = place.Address,
                Information = place.Information,
                Events = place.Events.Select(x => new EventLiteViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateTime = x.DateTime,
                    EventPhotos = x.EventPhotos.Select(y => y.Photo).ToList()
                }).ToList(),
                Sectors = place.Sectors.Select(x => new SectorViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Limit = x.Limit,
                    TypeId = x.TypeId
                }).ToList(),
                PlacePhotos = place.PlacePhotos.Select(x => $"/images/places/{x.Photo}").ToList()
            });
        }

        [HttpGet("GetSectorTypes")]
        public IActionResult GetSectorTypes()
        {
            return CreateSuccessRequestResult(data: _typeService.GetSectorTypes());
        }

        [HttpPost("AddPlace")]
        public IActionResult AddPlace([FromBody]PlaceViewModel placeViewModel)
        {
            var place = new Place
            {
                Name = placeViewModel.Name,
                Address = placeViewModel.Address,
                Information = placeViewModel.Information
            };

            _placeService.AddPlace(place, placeViewModel.Sectors?.Select(x => new SectorDTO
            {
                Title = x.Title,
                TypeId = x.TypeId,
                Limit = x.Limit,
                Seatings = x.Seatings?.Select(y => new SeatingDTO
                {
                    Row = y.Row,
                    SeatsCount = y.SeatsCount
                }).ToList()
            }).ToList());

            return CreateSuccessRequestResult();
        }
    }
}
