using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Cancellation
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public Payment Payment { get; set; }
    }
}