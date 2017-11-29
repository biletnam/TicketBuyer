using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User item)
        {
            _dbContext.Users.Add(item);
        }

        public IEnumerable<User> Find(Func<User, bool> condition)
        {
            return GetAll().AsEnumerable().Where(condition);
        }

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users.AsQueryable();
        }

        public void Remove(User item)
        {
            _dbContext.Users.Remove(item);
        }

        public void Update(User item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
