using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirBookings.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        [Column("Employee_Id")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}