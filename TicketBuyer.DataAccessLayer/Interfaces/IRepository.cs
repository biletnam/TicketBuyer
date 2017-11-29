using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketBuyer.DataAccessLayer.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> condition);

        void Add(T item);

        void Update(T item);

        void Remove(T item);
    }
}
