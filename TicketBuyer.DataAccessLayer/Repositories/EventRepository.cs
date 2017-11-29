using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        private readonly ApplicationDbContext _dbContext;

        public EventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Event item)
        {
            _dbContext.Events.Add(item);
        }

        public IEnumerable<Event> Find(Func<Event, bool> condition)
        {
            return _dbContext.Events.Where(condition).AsQueryable();
        }

        public IQueryable<Event> GetAll()
        {
            return _dbContext.Events.AsQueryable();
        }

        public void Remove(Event item)
        {
            _dbContext.Events.Remove(item);
        }

        public void Update(Event item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
