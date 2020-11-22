using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBookings.Models.Pageing
{
    public class ViewProducts
    {
        public IEnumerable<Product> Products { get; set; }
        public PagePag PagePag { get; set; }
    }
}