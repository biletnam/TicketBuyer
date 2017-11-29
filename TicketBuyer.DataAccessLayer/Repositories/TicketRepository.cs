using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly ApplicationDbContext _dbContext;

        public TicketRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Ticket item)
        {
            _dbContext.Tickets.Add(item);
        }

        public IEnumerable<Ticket> Find(Func<Ticket, bool> condition)
        {
            return GetAll().AsEnumerable().Where(condition);
        }

        public IQueryable<Ticket> GetAll()
        {
            return _dbContext.Tickets.Include(x => x.Event).Include(x => x.Event.Place).Include(x => x.Sector).Include(x => x.Seating).AsQueryable();
        }

        public void Remove(Ticket item)
        {
            _dbContext.Tickets.Remove(item);
        }

        public void Update(Ticket item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
