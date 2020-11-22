using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBookings.Models.Pageing
{
    public class PagePag
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalProducts { get; set; }
        public int TotalPages {
            get { return (int)Math.Ceiling((double)TotalProducts / PageSize); }
        } 
    }
}