using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class SalePlaceRepository : IRepository<SalePlace>
    {
        private readonly ApplicationDbContext _dbContext;

        public SalePlaceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<SalePlace> GetAll()
        {
            return _dbContext.SalePlaces.AsQueryable();
        }

        public IEnumerable<SalePlace> Find(Func<SalePlace, bool> condition)
        {
            return _dbContext.SalePlaces.Where(condition);
        }

        public void Add(SalePlace item)
        {
            _dbContext.SalePlaces.Add(item);
        }

        public void Update(SalePlace item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(SalePlace item)
        {
            _dbContext.SalePlaces.Remove(item);
        }
    }
}