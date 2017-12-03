using System;
using System.Collections.Generic;

namespace TicketBuyer.ViewModels
{
    public class EventViewModel : EventLiteViewModel
    {
        public string Information { get; set; }

        public IList<EventCommentViewModel> EventComments { get; set; }

        //public ICollection<EventPhoto> EventPhotos { get; set; }
    }
}
