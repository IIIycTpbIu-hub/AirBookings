using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirBookings.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "Имя исполнителя")]
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public ICollection<Product> Products { get; set; }
        public Employee()
        {
            Products = new List<Product>();
        }

    }
}