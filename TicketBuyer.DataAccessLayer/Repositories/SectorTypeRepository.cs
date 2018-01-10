using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class SectorTypeRepository : IRepository<SectorType>
    {
        private readonly ApplicationDbContext _dbContext;

        public SectorTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<SectorType> GetAll()
        {
            return _dbContext.SectorTypes.AsQueryable();
        }

        public IEnumerable<SectorType> Find(Func<SectorType, bool> condition)
        {
            return _dbContext.SectorTypes.Where(condition);
        }

        public void Add(SectorType item)
        {
            _dbContext.SectorTypes.Add(item);
        }

        public void Update(SectorType item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(SectorType item)
        {
            _dbContext.SectorTypes.Remove(item);
        }
    }
}