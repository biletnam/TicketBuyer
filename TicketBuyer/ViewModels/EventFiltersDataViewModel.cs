using System.Collections.Generic;

namespace TicketBuyer.ViewModels
{
    public class EventFiltersDataViewModel
    {
        public IList<PlaceLiteViewModel> Places { get; set; }

        public Dictionary<int, string> Types { get; set; }

        public Dictionary<int, string> Statuses { get; set; }
    }
}
