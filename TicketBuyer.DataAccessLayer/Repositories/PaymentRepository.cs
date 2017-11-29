using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;


namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Payment item)
        {
            _dbContext.Payments.Add(item);
        }

        public IEnumerable<Payment> Find(Func<Payment, bool> condition)
        {
            return _dbContext.Payments.Where(condition).AsQueryable();
        }

        public IQueryable<Payment> GetAll()
        {
            return _dbContext.Payments.AsQueryable();
        }

        public void Remove(Payment item)
        {
            _dbContext.Payments.Remove(item);
        }

        public void Update(Payment item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
