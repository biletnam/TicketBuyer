using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class EventNewsRepository : IRepository<EventNews>
    {
        private readonly ApplicationDbContext _dbContext;

        public EventNewsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<EventNews> GetAll()
        {
            return _dbContext.EventNews.AsQueryable();
        }

        public IEnumerable<EventNews> Find(Func<EventNews, bool> condition)
        {
            return _dbContext.EventNews.Where(condition);
        }

        public void Add(EventNews item)
        {
            _dbContext.EventNews.Add(item);
        }

        public void Update(EventNews item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(EventNews item)
        {
            _dbContext.EventNews.Remove(item);
        }
    }
}