using System.Collections.Generic;
using System.Linq;
using TicketBuyer.BusinessLogicLayer.Interfaces;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.BusinessLogicLayer.Services
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<SalePlace> GetSalePlaces()
        {
            return _unitOfWork.SalePlaceRepository.GetAll().ToList();
        }

        public IList<CompanyNews> GetCompanyNewses()
        {
            return _unitOfWork.CompanyNewsRepository.GetAll().ToList();
        }

        public IList<EventNews> GetEventNews()
        {
            return _unitOfWork.EventNewsRepository.GetAll().ToList();
        }
    }
}