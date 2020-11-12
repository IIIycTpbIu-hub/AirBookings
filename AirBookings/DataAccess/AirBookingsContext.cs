using AirBooking.Models;
using System.Data.Entity;

namespace AirBookings.DataAccess
{
    public class AirBookingsContext : DbContext
    {
        public DbSet<Aircraft> Aircrafts {get; set;}
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Seat> Seats { get; set; }

    }
}