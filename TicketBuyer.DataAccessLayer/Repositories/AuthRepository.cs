using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class AuthRepository : IRepository<Auth>
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Auth> GetAll()
        {
            return _dbContext.Auths.Include(x => x.User).AsQueryable();
        }

        public IEnumerable<Auth> Find(Func<Auth, bool> condition)
        {
            return GetAll().AsEnumerable().Where(condition);
        }

        public void Add(Auth item)
        {
            _dbContext.Auths.Add(item);
        }

        public void Update(Auth item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(Auth item)
        {
            _dbContext.Remove(item);
        }
    }
}