using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class SectorService : ISectorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SectorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public SectorDTO GetSector(int sectorId)
        {
            var sector = GetExistingSector(sectorId);

            return new SectorDTO
            {
                Id = sectorId,
                Type = sector.Type,
                Limit = sector.Limit,
                Title = sector.Title
            };
        }

        public IList<SectorDTO> GetSectors(int placeId)
        {
            var sectors = _unitOfWork.SectorRepository.Find(x => x.PlaceId == placeId);

            return sectors.Select(x => new SectorDTO
            {
                Id = x.Id,
                Type = x.Type,
                Limit = x.Limit,
                Title = x.Title
            }).ToList();
        }

        public void AddSector(int placeId, SectorDTO SectorDTO)
        {
            if (_unitOfWork.SectorRepository.Find(x => x.PlaceId == placeId && x.Title == SectorDTO.Title).Any())
            {
                throw new Exception();
            }

            var sector = new Sector
            {
                Title = SectorDTO.Title,
                Type = SectorDTO.Type,
                Limit = SectorDTO.Limit
            };

            // if (sector.Type == SectorType.Sitting && SectorDTO.)
        }

        public void AddSectors(int placeId, IList<SectorDTO> sectors)
        {
            foreach (var sector in sectors)
            {
                AddSector(placeId, sector);
            }
        }

        public void UpdateSector(SectorDTO SectorDTO)
        {
            var sector = GetExistingSector(SectorDTO.Id);

            sector.Title = SectorDTO.Title;
            sector.Type = SectorDTO.Type;
            sector.Limit = SectorDTO.Limit;
            //sitting

            _unitOfWork.SectorRepository.Update(sector);
            _unitOfWork.SaveChanges();
        }

        public void RemoveSector(int sectorId)
        {
            var sector = GetExistingSector(sectorId);

            _unitOfWork.SectorRepository.Remove(sector);
            _unitOfWork.SaveChanges();
        }

        private Sector GetExistingSector(int sectorId)
        {
            var sector = _unitOfWork.SectorRepository.Find(x => x.Id == sectorId).FirstOrDefault();

            if (sector == null)
            {
                throw new Exception();
            }

            return sector;
        }
    }
}