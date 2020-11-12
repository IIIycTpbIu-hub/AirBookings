using System.ComponentModel.DataAnnotations;

namespace AirBookings.Models
{
    public class Airport
    {
        [Key]
        public string AirportCode { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}