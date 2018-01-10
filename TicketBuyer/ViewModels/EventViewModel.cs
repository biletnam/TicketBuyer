using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TicketBuyer.ViewModels
{
    public class EventViewModel : EventLiteViewModel
    {
        public string Information { get; set; }

        public IList<EventCommentViewModel> EventComments { get; set; }
    }
}
