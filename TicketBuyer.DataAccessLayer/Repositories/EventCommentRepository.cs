using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class EventCommentRepository : IRepository<EventComment>
    {
        private readonly ApplicationDbContext _dbContext;

        public EventCommentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(EventComment item)
        {
            _dbContext.EventComments.Add(item);
        }

        public IEnumerable<EventComment> Find(Func<EventComment, bool> condition)
        {
            return _dbContext.EventComments.Where(condition);
        }

        public IQueryable<EventComment> GetAll()
        {
            return _dbContext.EventComments.Include(x => x.User).AsQueryable();
        }

        public void Remove(EventComment item)
        {
            _dbContext.EventComments.Remove(item);
        }

        public void Update(EventComment item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
