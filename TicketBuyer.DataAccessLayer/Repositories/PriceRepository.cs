using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class PriceRepository : IRepository<Price>
    {
        private readonly ApplicationDbContext _dbContext;

        public PriceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Price item)
        {
            _dbContext.Prices.Add(item);
        }

        public IEnumerable<Price> Find(Func<Price, bool> condition)
        {
            return _dbContext.Prices.Where(condition).AsQueryable();
        }

        public IQueryable<Price> GetAll()
        {
            return _dbContext.Prices.AsQueryable();
        }

        public void Remove(Price item)
        {
            _dbContext.Prices.Remove(item);
        }

        public void Update(Price item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
