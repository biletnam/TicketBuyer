using System;

namespace TicketBuyer.DataAccessLayer.Entities
{
    public class CompanyNews
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Article { get; set; }

        public DateTime DateTime { get; set; }
    }
}