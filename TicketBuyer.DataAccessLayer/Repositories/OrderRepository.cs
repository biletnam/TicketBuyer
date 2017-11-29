using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Order item)
        {
            _dbContext.Orders.Add(item);
        }

        public IEnumerable<Order> Find(Func<Order, bool> condition)
        {
            return GetAll().AsEnumerable().Where(condition);
        }

        public IQueryable<Order> GetAll()
        {
            return _dbContext.Orders.Include(x => x.Payment).AsQueryable();
        }

        public void Remove(Order item)
        {
            _dbContext.Orders.Remove(item);
        }

        public void Update(Order item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
