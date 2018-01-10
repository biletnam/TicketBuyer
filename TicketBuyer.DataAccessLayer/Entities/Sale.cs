using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        public float Percent { get; set; }

        public bool IsActive { get; set; }

        public ICollection<EventSale> EventSales { get; set; }
    }
}
