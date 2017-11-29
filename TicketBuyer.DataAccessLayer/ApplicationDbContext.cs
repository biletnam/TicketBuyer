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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=TicketBuyer;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            //modelbuilder.Entity<Sector>()
            //    .HasMany(s => s.Tickets)
            //    .WithOne(t => t.Sector)
            //    .OnDelete(DeleteBehavior.Restrict); // no ON DELETE

            modelbuilder.Entity<Ticket>()
                .HasOne(t => t.Sector)
                .WithMany(s => s.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Price>()
                .HasOne(t => t.Sector)
                .WithMany(s => s.Prices)
                .OnDelete(DeleteBehavior.Restrict);
            //modelbuilder.Entity(typeof(Ticket))
            //    .HasOne(typeof(Sector), "Sector")
            //    .WithMany()
            //    .HasForeignKey("SectorId")
            //    .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
        }
    }

}
