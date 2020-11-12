using System.ComponentModel.DataAnnotations.Schema;

namespace AirBookings .Models
{
    public class Seat
    {
        public int Id { get; set; }

        //[ForeignKey("Aircraft")]
        public int AircraftId { get; set; }
        public string SeatNumber { get; set; }
    }
}