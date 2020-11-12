using System.ComponentModel.DataAnnotations.Schema;

namespace AirBooking.Models
{
    public class Seat
    {
        public int Id { get; set; }

        //[ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public int SeatNumber { get; set; }
    }
}