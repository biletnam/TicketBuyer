using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _eventService;

        public PlaceService(IUnitOfWork unitOfWork, IEventService eventService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
        }

        public PlaceDTO GetPlace(int placeId)
        {
            var place = GetExistingPlace(placeId);

            var events = _eventService.GetEventsByPlace(placeId);

            return new PlaceDTO
            {
                Id = place.Id,
                Name = place.Name,
                Address = place.Address,
                Information = place.Information,
                Events = events
            };
        }

        public PlaceLiteDTO GetPlaceLite(int placeId)
        {
            var place = GetExistingPlace(placeId);

            return new PlaceLiteDTO
            {
                Id = place.Id,
                Name = place.Name,
                Address = place.Address,
            };
        }

        public IList<PlaceLiteDTO> GetPlaces()
        {
            var places = _unitOfWork.PlaceRepository.GetAll();

            return Map(places);
        }

        public void AddPlace(PlaceDTO placeDTO)
        {
            if (_unitOfWork.PlaceRepository
                .Find(x => x.Name == placeDTO.Name && x.Address == placeDTO.Address).Any())
            {
                throw new Exception();
            }

            if (placeDTO.Sectors.Count > 0)
            {

            }

            var place = new Place
            {
                Name = placeDTO.Name,
                Address = placeDTO.Address,
                Information = placeDTO.Information,
                //Sectors = PlaceDTO.Sectors.Select(x => )
            };

            _unitOfWork.PlaceRepository.Add(place);
            _unitOfWork.SaveChanges();

        }

        public void UpdatePlace(PlaceDTO placeDTO)
        {
            var place = GetExistingPlace(placeDTO.Id);

            place.Address = placeDTO.Address;
            place.Information = placeDTO.Information;
            placeDTO.Name = placeDTO.Name;

            _unitOfWork.PlaceRepository.Update(place);
            _unitOfWork.SaveChanges();
        }

        public void UpdateSectors(int placeId, IList<SectorDTO> sectors)
        {
            throw new NotImplementedException();
        }

        public void RemovePlace(PlaceDTO placeDTO)
        {
            var place = GetExistingPlace(placeDTO.Id);

            _unitOfWork.PlaceRepository.Remove(place);
            _unitOfWork.SaveChanges();
        }

        private Place GetExistingPlace(int placeId)
        {
            var place = _unitOfWork.PlaceRepository.Find(x => x.Id == placeId).FirstOrDefault();

            if (place == null)
            {
                throw new Exception();
            }

            return place;
        }

        private IList<PlaceLiteDTO> Map(IEnumerable<Place> places)
        {
            return places.Select(x => new PlaceLiteDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address
            }).ToList();
        }
    }
}