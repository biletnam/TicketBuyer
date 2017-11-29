using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class PlacePhoto
    {
        [Key]
        public int Id { get; set; }

        public int PlaceId { get; set; }

        public string Photo { get; set; }

        [ForeignKey("PlaceId")]
        public Place Place { get; set; }
    }
}
