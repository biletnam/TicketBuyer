using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class EventStatusRepository : IRepository<EventStatus>
    {
        private readonly ApplicationDbContext _dbContext;

        public EventStatusRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<EventStatus> GetAll()
        {
            return _dbContext.EventStatuses.AsQueryable();
        }

        public IEnumerable<EventStatus> Find(Func<EventStatus, bool> condition)
        {
            return _dbContext.EventStatuses.Where(condition);
        }

        public void Add(EventStatus item)
        {
            _dbContext.EventStatuses.Add(item);
        }

        public void Update(EventStatus item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(EventStatus item)
        {
            _dbContext.EventStatuses.Remove(item);
        }
    }
}