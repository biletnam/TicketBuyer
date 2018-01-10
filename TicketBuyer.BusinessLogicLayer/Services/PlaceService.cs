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

        public PlaceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Place GetPlace(int placeId)
        {
            var place = GetExistingPlace(placeId);

            place.Events = _unitOfWork.EventRepository.Find(x => x.PlaceId == placeId).ToList();
            place.Sectors = _unitOfWork.SectorRepository.Find(x => x.PlaceId == placeId).ToList();
            place.PlacePhotos = _unitOfWork.PlacePhotoRepository.Find(x => x.PlaceId == placeId).ToList();
            
            return place;
        }

        public Place GetPlaceLite(int placeId)
        {
            return GetExistingPlace(placeId);
        }

        public IList<Place> GetPlaces()
        {
            return _unitOfWork.PlaceRepository.GetAll().ToList();
        }

        public void AddPlace(Place place, IList<SectorDTO> sectors)
        {
            if (_unitOfWork.PlaceRepository
                .Find(x => x.Name == place.Name && x.Address == place.Address).Any())
            {
                throw new Exception();
            }

            _unitOfWork.PlaceRepository.Add(place);

            if (sectors != null && sectors.Count > 0)
            {
                foreach (var sectorDto in sectors)
                {
                    var sector = new Sector
                    {
                        Title = sectorDto.Title,
                        Limit = sectorDto.Limit,
                        PlaceId = place.Id,
                        TypeId = sectorDto.TypeId
                    };

                    _unitOfWork.SectorRepository.Add(sector);

                    if (sectorDto.TypeId == 2 && sectorDto.Seatings != null)
                    {
                        foreach (var seatingDto in sectorDto.Seatings)
                        {
                            for (var i = 1; i <= seatingDto.SeatsCount; i++)
                            {
                                var seating = new Seating
                                {
                                    Row = seatingDto.Row,
                                    Seat = i,
                                    SectorId = sector.Id
                                };

                                _unitOfWork.SeatingRepository.Add(seating);
                            }
                        }
                    }
                }
            }
            _unitOfWork.SaveChanges();

        }

        public void UpdatePlace(Place place)
        {
            var existingPlace = GetExistingPlace(place.Id);

            existingPlace.Address = place.Address;
            existingPlace.Information = place.Information;
            existingPlace.Name = place.Name;

            _unitOfWork.PlaceRepository.Update(place);
            _unitOfWork.SaveChanges();
        }

        public void UpdateSectors(int placeId, IList<Sector> sectors)
        {
            throw new NotImplementedException();
        }

        public void RemovePlace(int placeId)
        {
            var place = GetExistingPlace(placeId);

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
    }
}