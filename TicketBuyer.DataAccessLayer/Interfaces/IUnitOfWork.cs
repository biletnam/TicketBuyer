using System;
using System.Collections.Generic;
using System.Text;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<EventComment> EventCommentRepository { get; }

        IRepository<EventPhoto> EventPhotoRepository { get; }

        IRepository<Event> EventRepository { get; }

        IRepository<Order> OrderRepository { get; }

        IRepository<Payment> PaymentRepository { get; }

        IRepository<PlacePhoto> PlacePhotoRepository { get; }

        IRepository<Place> PlaceRepository { get; }

        IRepository<Seating> SeatingRepository { get; }

        IRepository<Sector> SectorRepository { get; }

        IRepository<Ticket> TicketRepository { get; }

        IRepository<Price> PriceRepository { get; }

        IRepository<User> UserRepository { get; }

        IRepository<WishEvent> WishEventRepository { get; }

        void SaveChanges();
    }
}
