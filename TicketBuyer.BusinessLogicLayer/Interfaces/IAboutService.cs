using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface IAboutService
    {
        IList<SalePlace> GetSalePlaces();

        IList<CompanyNews> GetCompanyNewses();

        IList<EventNews> GetEventNews();
    }
}