using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBookings.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public int? EmployerId { get; set; }
        public Employee Employee { get; set; }
    }
}