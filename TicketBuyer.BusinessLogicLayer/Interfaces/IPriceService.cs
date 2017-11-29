using System.Collections.Generic;
using TicketBuyer.BusinessLogicLayer.DTO;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IPriceService
    {
        IList<PriceDTO> GetPrices(int eventId);

        void AddPrice(PriceDTO priceDto);

        void AddPrices(IList<PriceDTO> priceDtos);

        void ChangePrice(PriceDTO priceDto);
    }
}