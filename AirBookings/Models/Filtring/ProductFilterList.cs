﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBookings.Models.Filtring
{
    public class ProductFilterList
    {
        public IEnumerable<Product> Products { get; set; }
        public SelectList Employees { get; set; }
    }
}