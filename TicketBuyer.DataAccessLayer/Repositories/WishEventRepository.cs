using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;


namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class WishEventRepository : IRepository<WishEvent>
    {
        private readonly ApplicationDbContext _dbContext;

        public WishEventRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(WishEvent item)
        {
            _dbContext.WishEvents.Add(item);
        }

        public IEnumerable<WishEvent> Find(Func<WishEvent, bool> condition)
        {
            return GetAll().AsEnumerable().Where(condition).AsQueryable();
        }

        public IQueryable<WishEvent> GetAll()
        {
            return _dbContext.WishEvents.Include(x => x.Event).AsQueryable();
        }

        public void Remove(WishEvent item)
        {
            _dbContext.WishEvents.Remove(item);
        }

        public void Update(WishEvent item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
