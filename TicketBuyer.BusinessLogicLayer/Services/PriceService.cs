using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class PriceService : IPriceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PriceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<PriceDTO> GetPrices(int eventId)
        {
            var prices = _unitOfWork.PriceRepository.Find(x => x.EventId == eventId);

            return prices.Select(x => new PriceDTO
            {
                Id = x.Id,
                EventId = x.EventId,
                SectorId = x.SectorId,
                Price = x.EventPrice
            }).ToList();
        }

        public void AddPrice(PriceDTO priceDto)
        {
            var price = new Price
            {
                EventId = priceDto.EventId,
                SectorId = priceDto.SectorId,
                EventPrice = priceDto.Price
            };

            _unitOfWork.PriceRepository.Add(price);
            _unitOfWork.SaveChanges();
        }

        public void AddPrices(IList<PriceDTO> priceDtos)
        {
            foreach (var priceDto in priceDtos)
            {
                AddPrice(priceDto);
            }
        }

        public void ChangePrice(PriceDTO priceDto)
        {
            var price = _unitOfWork.PriceRepository.Find(x => x.Id == priceDto.Id).FirstOrDefault();

            if (price == null)
            {
                throw new Exception();
            }

            price.EventPrice = priceDto.Price;

            _unitOfWork.PriceRepository.Update(price);
            _unitOfWork.SaveChanges();
        }
    }
}