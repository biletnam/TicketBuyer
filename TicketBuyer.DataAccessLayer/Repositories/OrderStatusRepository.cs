using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class OrderStatusRepository : IRepository<OrderStatus>
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderStatusRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<OrderStatus> GetAll()
        {
            return _dbContext.OrderStatuses.AsQueryable();
        }

        public IEnumerable<OrderStatus> Find(Func<OrderStatus, bool> condition)
        {
            return _dbContext.OrderStatuses.Where(condition);
        }

        public void Add(OrderStatus item)
        {
            _dbContext.OrderStatuses.Add(item);
        }

        public void Update(OrderStatus item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(OrderStatus item)
        {
            _dbContext.OrderStatuses.Remove(item);
        }
    }
}