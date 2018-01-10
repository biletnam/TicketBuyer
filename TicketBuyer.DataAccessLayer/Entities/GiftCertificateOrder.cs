using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class GiftCertificateOrder
    {
        public int Id { get; set; }

        public int GiftCertificateId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("GiftCertificateId")]
        public GiftCertificate GiftCertificate { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}