using AirBookings.DataAccess;
using AirBookings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBookings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AirBookingsContext db = new AirBookingsContext();
            var result = db.Aircrafts.ToList().Count;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}