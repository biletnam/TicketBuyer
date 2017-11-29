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

        public UnitOfWork(ApplicationDbContext dbContext, IRepository<EventComment> eventCommentRepository, IRepository<EventPhoto> eventPhotoRepository, IRepository<Event> eventRepository,
            IRepository<Order> orderRepository, IRepository<Payment> paymentRepository, IRepository<PlacePhoto> placePhotoRepository, IRepository<Place> placeRepository,
            IRepository<Seating> seatingRepository, IRepository<Sector> sectorRepository, IRepository<Ticket> ticketRepository, IRepository<Price> priceRepository,
            IRepository<User> userRepository, IRepository<WishEvent> wishEventRepository)
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
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}