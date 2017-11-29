namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class SeatingDTO
    {
        public int Id { get; set; }

        public int SectorId { get; set; }

        public int Row { get; set; }

        public int Seat { get; set; }

        public bool IsFree { get; set; }
    }
}