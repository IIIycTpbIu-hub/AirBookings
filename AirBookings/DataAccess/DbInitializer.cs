using AirBookings.Models;
using System.Data.Entity;

namespace AirBookings.DataAccess
{
    public class DbInitializer : DropCreateDatabaseAlways<AirBookingsContext>
    {
        protected override void Seed(AirBookingsContext context)
        {
            context.Aircrafts.Add(new Aircraft() { Id = 1, Model = "SU-31", Range = 2000 });
        }
    }
}