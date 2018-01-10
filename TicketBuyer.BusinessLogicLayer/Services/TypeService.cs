using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Dictionary<int, string> GetEventTypes()
        {
            return _unitOfWork.EventTypeRepository.GetAll().ToDictionary(x => x.Id, x => x.Title);
        }

        public Dictionary<int, string> GetEventStatuses()
        {
            return _unitOfWork.EventStatusRepository.GetAll().ToDictionary(x => x.Id, x => x.Title);
        }

        public Dictionary<int, string> GetOrderStatuses()
        {
            return _unitOfWork.OrderStatusRepository.GetAll().ToDictionary(x => x.Id, x => x.Title);
        }

        public Dictionary<int, string> GetSectorTypes()
        {
            return _unitOfWork.SectorTypeRepository.GetAll().ToDictionary(x => x.Id, x => x.Title);
        }
    }
}