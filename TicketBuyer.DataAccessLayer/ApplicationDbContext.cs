using Microsoft.EntityFrameworkCore;
using TicketBuyer.DataAccessLayer.Entities;

namespace TicketBuyer.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventComment> EventComments { get; set; }

        public DbSet<EventPhoto> EventPhotos { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PlacePhoto> PlacePhotos { get; set; }

        public DbSet<Seating> Seatings { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<WishEvent> WishEvents { get; set; }

        public DbSet<Auth> Auths { get; set; }

        public DbSet<Cancellation> Cancellations { get; set; }

        public DbSet<CompanyNews> CompanyNews { get; set; }

        public DbSet<EventNews> EventNews { get; set; }

        public DbSet<EventSale> EventSales { get; set; }

        public DbSet<EventStatus> EventStatuses { get; set; }

        public DbSet<EventType> EventTypes { get; set; }

        public DbSet<GiftCertificate> GiftCertificates { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<NotificationDefenition> NotificationDefenitions { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SalePlace> SalePlaces { get; set; }

        public DbSet<SectorType> SectorTypes { get; set; }

        public DbSet<UserPreference> UserPreferences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TicketBuyer;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Ticket>()
                .HasOne(t => t.Sector)
                .WithMany(s => s.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Price>()
                .HasOne(t => t.Sector)
                .WithMany(s => s.Prices)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<User>()
                .HasOne(x => x.Auth)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
