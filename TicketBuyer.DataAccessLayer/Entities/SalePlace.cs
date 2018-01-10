using System.ComponentModel.DataAnnotations;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class SalePlace
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}