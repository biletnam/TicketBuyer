using System.Collections.Generic;

namespace TicketBuyer.BusinessLogicLayer.Interfaces
{
    public interface ITypeService
    {
        Dictionary<int, string> GetEventTypes();
        Dictionary<int, string> GetEventStatuses();
        Dictionary<int, string> GetOrderStatuses();
        Dictionary<int, string> GetSectorTypes();

    }
}