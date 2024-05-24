using EntityFrameworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApi.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options) { }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ClientTrip> ClientTrips { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTrip> CountryTrips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTrip>().ToTable("Client", "trip");
            modelBuilder.Entity<Trip>().ToTable("Trip", "trip");
            modelBuilder.Entity<ClientTrip>().ToTable("Client_Trip", "trip");
            modelBuilder.Entity<Country>().ToTable("Country", "trip");
            modelBuilder.Entity<CountryTrip>().ToTable("Country_Trip", "trip");

            modelBuilder.Entity<ClientTrip>()
                .HasKey(ct => new { ct.IdClient, ct.IdTrip });
            
            modelBuilder.Entity<ClientTrip>()
                .HasOne(ct => ct.Client)
                .WithMany(c => c.ClientTrips)
                .HasForeignKey(ct => ct.IdClient);

            modelBuilder.Entity<ClientTrip>()
                .HasOne(ct => ct.Trip)
                .WithMany(t => t.ClientTrips)
                .HasForeignKey(ct => ct.IdTrip);
            
            modelBuilder.Entity<CountryTrip>()
                .HasKey(ct => new { ct.IdCountry, ct.IdTrip });
            
            modelBuilder.Entity<CountryTrip>()
                .HasOne(ct => ct.Country)
                .WithMany(c => c.CountryTrips)
                .HasForeignKey(ct => ct.IdCountry);

            modelBuilder.Entity<CountryTrip>()
                .HasOne(ct => ct.Trip)
                .WithMany(t => t.CountryTrips)
                .HasForeignKey(ct => ct.IdTrip);

            modelBuilder.Entity<Country>()
                .HasKey(c => c.IdCountry);
        }
        }
    }