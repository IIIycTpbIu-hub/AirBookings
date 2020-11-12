using System.ComponentModel.DataAnnotations.Schema;

namespace AirBooking.Models
{
    public class Booking
    {
        public int Id { get; set; }

        //[ForeignKey("Flight")]
        public int FlightId { get; set; }

        //[ForeignKey("Seat")]
        public int SeatId { get; set; }

        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
    }
}