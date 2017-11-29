using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;


namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class SeatingRepository : IRepository<Seating>
    {
        private readonly ApplicationDbContext _dbContext;

        public SeatingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Seating item)
        {
            _dbContext.Seatings.Add(item);
        }

        public IEnumerable<Seating> Find(Func<Seating, bool> condition)
        {
            return _dbContext.Seatings.Where(condition);
        }

        public IQueryable<Seating> GetAll()
        {
            return _dbContext.Seatings.AsQueryable();
        }

        public void Remove(Seating item)
        {
            _dbContext.Seatings.Remove(item);
        }

        public void Update(Seating item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
