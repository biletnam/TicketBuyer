using TicketBuyer.DataAccessLayer.Entities;
using TicketBuyer.DataAccessLayer.Interfaces;

namespace TicketBuyer.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IRepository<EventComment> EventCommentRepository { get; }

        public IRepository<EventPhoto> EventPhotoRepository { get; }

        public IRepository<Event> EventRepository { get; }

        public IRepository<Order> OrderRepository { get; }

        public IRepository<Payment> PaymentRepository { get; }

        public IRepository<PlacePhoto> PlacePhotoRepository { get; }

        public IRepository<Place> PlaceRepository { get; }

        public IRepository<Seating> SeatingRepository { get; }

        public IRepository<Sector> SectorRepository { get; }

        public IRepository<Ticket> TicketRepository { get; }

        public IRepository<Price> PriceRepository { get; }

        public IRepository<User> UserRepository { get; }

        public IRepository<WishEvent> WishEventRepository { get; }

        public IRepository<Auth> AuthRepository { get; }

        public IRepository<Cancellation> CancellationRepository { get; }

        public IRepository<CompanyNews> CompanyNewsRepository { get; }

        public IRepository<EventNews> EventNewsRepository { get; }

        public IRepository<EventSale> EventSaleRepository { get; }

        public IRepository<EventStatus> EventStatusRepository { get; }

        public IRepository<EventType> EventTypeRepository { get; }

        public IRepository<GiftCertificate> GiftCertificateRepository { get; }

        public IRepository<Notification> NotificationRepository { get; }

        public IRepository<NotificationDefenition> NotificationDefenitionRepository { get; }

        public IRepository<OrderStatus> OrderStatusRepository { get; }

        public IRepository<PaymentType> PaymentTypeRepository { get; }

        public IRepository<Role> RoleRepository { get; }

        public IRepository<Sale> SaleRepository { get; }

        public IRepository<SalePlace> SalePlaceRepository { get; }

        public IRepository<SectorType> SectorTypeRepository { get; }

        public IRepository<UserPreference> UserPreferenceRepository { get; }

        public UnitOfWork(ApplicationDbContext dbContext, IRepository<EventComment> eventCommentRepository, IRepository<EventPhoto> eventPhotoRepository, IRepository<Event> eventRepository,
            IRepository<Order> orderRepository, IRepository<Payment> paymentRepository, IRepository<PlacePhoto> placePhotoRepository, IRepository<Place> placeRepository,
            IRepository<Seating> seatingRepository, IRepository<Sector> sectorRepository, IRepository<Ticket> ticketRepository, IRepository<Price> priceRepository,
            IRepository<User> userRepository, IRepository<WishEvent> wishEventRepository, IRepository<Auth> authRepository, IRepository<EventStatus> eventStatusRepository,
            IRepository<EventType> eventTypeRepository, IRepository<OrderStatus> orderStatusRepository, IRepository<SectorType> sectorTypeRepository,
            IRepository<CompanyNews> companyNewsRepository, IRepository<EventNews> eventNewsRepository, IRepository<SalePlace> salePlaceRepository
            //, IRepository<UserPreference> userPreferenceRepository)
            // IRepository<Cancellation> cancellationRepository,
            // IRepository<EventSale> eventSaleRepository, 
            // IRepository<GiftCertificate> giftCertificateRepository, IRepository<Notification> notificationRepository, IRepository<NotificationDefenition> notificationDefenitionRepository,
            // IRepository<PaymentType> paymentTypeRepository, IRepository<Role> roleRepository, IRepository<Sale> saleRepository, 
            )
        {
            _dbContext = dbContext;
            EventCommentRepository = eventCommentRepository;
            EventPhotoRepository = eventPhotoRepository;
            EventRepository = eventRepository;
            OrderRepository = orderRepository;
            PaymentRepository = paymentRepository;
            PlacePhotoRepository = placePhotoRepository;
            PlaceRepository = placeRepository;
            SeatingRepository = seatingRepository;
            SectorRepository = sectorRepository;
            TicketRepository = ticketRepository;
            PriceRepository = priceRepository;
            UserRepository = userRepository;
            WishEventRepository = wishEventRepository;
            AuthRepository = authRepository;
            //CancellationRepository = cancellationRepository;
            CompanyNewsRepository = companyNewsRepository;
            EventNewsRepository = eventNewsRepository;
            //EventSaleRepository = eventSaleRepository;
            EventStatusRepository = eventStatusRepository;
            EventTypeRepository = eventTypeRepository;
            //GiftCertificateRepository = giftCertificateRepository;
            //NotificationRepository = notificationRepository;
            //NotificationDefenitionRepository = notificationDefenitionRepository;
            OrderStatusRepository = orderStatusRepository;
            //PaymentTypeRepository = paymentTypeRepository;
            //RoleRepository = roleRepository;
            //SaleRepository = saleRepository;
            SalePlaceRepository = salePlaceRepository;
            SectorTypeRepository = sectorTypeRepository;
            //UserPreferenceRepository = userPreferenceRepository;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}