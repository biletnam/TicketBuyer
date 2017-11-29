using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer.Repositories
{
    public class PlacePhotoRepository : IRepository<PlacePhoto>
    {
        private readonly ApplicationDbContext _dbContext;

        public PlacePhotoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(PlacePhoto item)
        {
            _dbContext.PlacePhotos.Add(item);
        }

        public IEnumerable<PlacePhoto> Find(Func<PlacePhoto, bool> condition)
        {
            return _dbContext.PlacePhotos.Where(condition).AsQueryable();
        }

        public IQueryable<PlacePhoto> GetAll()
        {
            return _dbContext.PlacePhotos.AsQueryable();
        }

        public void Remove(PlacePhoto item)
        {
            _dbContext.PlacePhotos.Remove(item);
        }

        public void Update(PlacePhoto item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
