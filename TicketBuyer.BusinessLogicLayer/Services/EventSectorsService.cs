using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.DTO;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class EventSectorsService : IEventSectorsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventSectorsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool IsSectorLimitReached(int sectorId, int eventId)
        {
            var limit = _unitOfWork.SectorRepository.Find(x => x.Id == sectorId).FirstOrDefault().Limit;
            var ticketsCount = _unitOfWork.TicketRepository.Find(x => x.EventId == eventId && x.SectorId == sectorId).Count();

            return limit == ticketsCount;
        }

        public IList<SeatingDTO> GetSeatings(int sectorId, int eventId)
        {
            var seatings = _unitOfWork.SeatingRepository.Find(x => x.SectorId == sectorId);
            var tickets = _unitOfWork.TicketRepository.Find(x => x.EventId == eventId && x.SectorId == sectorId);

            return seatings.Select(x => new SeatingDTO
            {
                Id = x.Id,
                Row = x.Row,
                Seat = x.Seat,
                IsFree = tickets.All(y => y.SeatingId != x.Id)
            }).ToList();
        }
    }
}