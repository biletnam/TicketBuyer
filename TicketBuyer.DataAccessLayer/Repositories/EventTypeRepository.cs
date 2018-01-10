using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class EventTypeRepository : IRepository<EventType>
    {
        private readonly ApplicationDbContext _dbContext;

        public EventTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<EventType> GetAll()
        {
            return _dbContext.EventTypes.AsQueryable();
        }

        public IEnumerable<EventType> Find(Func<EventType, bool> condition)
        {
            return _dbContext.EventTypes.Where(condition);
        }

        public void Add(EventType item)
        {
            _dbContext.EventTypes.Add(item);
        }

        public void Update(EventType item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(EventType item)
        {
            _dbContext.EventTypes.Remove(item);
        }
    }
}