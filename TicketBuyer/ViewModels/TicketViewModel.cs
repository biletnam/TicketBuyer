namespace TicketBuyer.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public EventViewModel Event { get; set; }

        public SectorViewModel Sector { get; set; }

        public SeatingViewModel Seating {get;set;}
    }
}
