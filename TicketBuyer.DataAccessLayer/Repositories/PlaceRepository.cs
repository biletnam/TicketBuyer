using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class PlaceRepository : IRepository<Place>
    {
        private ApplicationDbContext _dbContext;

        public PlaceRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Place item)
        {
            _dbContext.Places.Add(item);
        }

        public IEnumerable<Place> Find(Func<Place, bool> condition)
        {
            return _dbContext.Places.Where(condition).AsQueryable();
        }

        public IQueryable<Place> GetAll()
        {
            return _dbContext.Places.Include(x => x.PlacePhotos).AsQueryable();
        }

        public void Remove(Place item)
        {
            _dbContext.Places.Remove(item);
        }

        public void Update(Place item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
