
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class GiftCertificate
    {
        [Key]
        public int Id { get; set; }

        public float Price { get; set; }

        public ICollection<GiftCertificateOrder> GiftCertificateOrders { get; set; }
    }
}