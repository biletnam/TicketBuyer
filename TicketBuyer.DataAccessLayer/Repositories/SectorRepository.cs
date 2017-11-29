using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class SectorRepository : IRepository<Sector>
    {
        private readonly ApplicationDbContext _dbContext;

        public SectorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Sector item)
        {
            _dbContext.Sectors.Add(item);
        }

        public IEnumerable<Sector> Find(Func<Sector, bool> condition)
        {
            return GetAll().AsEnumerable().Where(condition).AsQueryable();
        }

        public IQueryable<Sector> GetAll()
        {
            return _dbContext.Sectors.Include(x => x.Seatings).AsQueryable();
        }

        public void Remove(Sector item)
        {
            _dbContext.Sectors.Remove(item);
        }

        public void Update(Sector item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
