using System.Collections.Generic;

namespace TicketBuyer.ViewModels
{
    public class AboutViewModel
    {
        public IList<CompanyNewsViewModel> CompanyNews { get; set; }

        public IList<EventNewsViewModels> EventNews { get; set; }

        public IList<SalePlaceViewModel> SalePlaces { get; set; }
    }
}
