namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class WishEventDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        public EventLiteDTO Event { get; set; }
    }
}