using flight_booking_service.Models;
using Microsoft.EntityFrameworkCore;

namespace hotel_booking_service.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Airline> Airlines { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}