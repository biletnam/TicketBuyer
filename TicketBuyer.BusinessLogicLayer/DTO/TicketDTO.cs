namespace TicketBuyer.BusinessLogicLayer.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int EventId { get; set; }

        public int SectorId { get; set; }

        public int? SeatingId { get; set; }

        public float Price { get; set; }
        
        public EventDTO Event { get; set; }

        public SectorDTO Sector { get; set; }

        //seating

       // [ForeignKey("SeatingId")]
       // public Seating Seating { get; set; }
    }
}