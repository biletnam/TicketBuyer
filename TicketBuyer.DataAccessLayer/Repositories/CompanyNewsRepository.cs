using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class CompanyNewsRepository : IRepository<CompanyNews>
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyNewsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<CompanyNews> GetAll()
        {
            return _dbContext.CompanyNews.AsQueryable();
        }

        public IEnumerable<CompanyNews> Find(Func<CompanyNews, bool> condition)
        {
            return _dbContext.CompanyNews.Where(condition);
        }

        public void Add(CompanyNews item)
        {
            _dbContext.CompanyNews.Add(item);
        }

        public void Update(CompanyNews item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(CompanyNews item)
        {
            _dbContext.CompanyNews.Remove(item);
        }
    }
}