using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;


namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class EventPhotoRepository : IRepository<EventPhoto>
    {
        private readonly ApplicationDbContext _dbContext;

        public EventPhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(EventPhoto item)
        {
            _dbContext.EventPhotos.Add(item);
        }

        public IEnumerable<EventPhoto> Find(Func<EventPhoto, bool> condition)
        {
            return _dbContext.EventPhotos.Where(condition).AsQueryable();
        }

        public IQueryable<EventPhoto> GetAll()
        {
            return _dbContext.EventPhotos.AsQueryable();
        }

        public void Remove(EventPhoto item)
        {
            _dbContext.EventPhotos.Remove(item);
        }

        public void Update(EventPhoto item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
