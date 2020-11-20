using AirBookings.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirBookings.DataAccess
{
    public class Lab3Context : DbContext 
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}