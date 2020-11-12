using AirBookings.Models;
using System.Data.Entity;

namespace AirBookings.DataAccess
{
    public class DbInitializer : DropCreateDatabaseAlways<AirBookingsContext>
    {
        protected override void Seed(AirBookingsContext context)
        {
            context.Aircrafts.Add(new Aircraft() { Id = 1, Model = "SU-31", Range = 2000 });
            context.Seats.Add(new Seat() { Id = 1, AircraftId = 1, Seat = "1A" });
            context.Seats.Add(new Seat() { Id = 2, AircraftId = 1, Seat = "1B" });
            context.Seats.Add(new Seat() { Id = 3, AircraftId = 1, Seat = "1C" });
            context.Airports.Add(new Airport() { AirportCode = "VKO", City = "Москва", Name = "Международный аэропорт Внуково" });
            context.Airports.Add(new Airport() { AirportCode = "VOG", City = "Волгоград", Name = "Гумрак(аэропорт)" });
            context.Flights.Add(new Flight()
            {
                Id = 1,
                AircraftId = 1,
                DepartureAirport = "VOG",
                ArrivalAirport = "VKO",
                ScheduledDeparture = new System.DateTime(
                                                            year: 2020, 
                                                            month: 11, 
                                                            day: 12, 
                                                            hour: 21, 
                                                            minute: 30, 
                                                            second:00
                                                        ),
                ScheduledArriving = new System.DateTime(
                                                            year: 2020,
                                                            month: 11,
                                                            day: 12,
                                                            hour: 23,
                                                            minute: 00,
                                                            second: 00
                                                        ),
            }); 
        }
    }
}