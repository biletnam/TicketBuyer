using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBuyer.ViewModels
{
    public class PlaceViewModel : PlaceLiteViewModel
    {
        public string Information { get; set; }

        public IList<EventLiteViewModel> Events { get; set; }

        public ICollection<SectorViewModel> Sectors { get; set; }

        //public ICollection<PlacePhoto> PlacePhotos { get; set; }
    }
}
