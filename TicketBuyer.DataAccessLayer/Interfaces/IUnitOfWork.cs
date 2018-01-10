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

        IRepository<Auth> AuthRepository { get; }

        IRepository<Cancellation> CancellationRepository { get; }

        IRepository<CompanyNews> CompanyNewsRepository { get; }

        IRepository<EventNews> EventNewsRepository { get; }

        IRepository<EventSale> EventSaleRepository { get; }

        IRepository<EventStatus> EventStatusRepository { get; }

        IRepository<EventType> EventTypeRepository { get; }

        IRepository<GiftCertificate> GiftCertificateRepository { get; }

        IRepository<Notification> NotificationRepository { get; }

        IRepository<NotificationDefenition> NotificationDefenitionRepository { get; }

        IRepository<OrderStatus> OrderStatusRepository { get; }

        IRepository<PaymentType> PaymentTypeRepository { get; }

        IRepository<Role> RoleRepository { get; }

        IRepository<Sale> SaleRepository { get; }

        IRepository<SalePlace> SalePlaceRepository { get; }

        IRepository<SectorType> SectorTypeRepository { get; }

        IRepository<UserPreference> UserPreferenceRepository { get; }

        void SaveChanges();
    }
}
