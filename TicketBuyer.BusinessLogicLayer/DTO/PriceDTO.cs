namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class PriceDTO
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public int SectorId { get; set; }

        public float Price { get; set; }
    }
}