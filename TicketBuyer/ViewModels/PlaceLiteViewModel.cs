using System.Collections.Generic;

namespace TicketBuyer.ViewModels
{
    public class PlaceLiteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IList<string> PlacePhotos { get; set; }
    }
}
