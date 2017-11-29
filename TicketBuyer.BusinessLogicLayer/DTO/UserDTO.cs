using System.Collections.Generic;

namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class UserDTO : UserLiteDTO
    {
        public IList<EventCommentDTO> EventComments { get; set; }

        public IList<OrderDTO> Orders { get; set; }

        public IList<WishEventDTO> WishEvents { get; set; }
    }
}