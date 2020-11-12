using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirBookings.Models
{
    public class Flight
    {
        public int Id { get; set; }

        //[ForeignKey("Aircraft")]
        public int AircraftId { get; set; }

        //[ForeignKey("Airport")]
        public string DepartureAirport { get; set; }
        public DateTime ScheduledDeparture { get; set; }

        //[ForeignKey("Airport")]
        public string ArrivalAirport { get; set; }
        public DateTime ScheduledArriving { get; set; }
    }
}