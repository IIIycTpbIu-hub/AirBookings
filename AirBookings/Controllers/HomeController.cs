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
        AirBookingsContext db = new AirBookingsContext();
        public ActionResult Index()
        {
            var flights = db.Flights.ToArray();
            ViewBag.Flights = flights;

            var aircrafts = db.Aircrafts.ToArray();
            ViewBag.Aircrafts = from a in aircrafts
                                from f in flights
                                where a.Id == f.AircraftId
                                select a;
            var seats = db.Seats.ToArray();
            ViewBag.Seats = from s in seats
                            from a in aircrafts
                            where s.AircraftId == a.Id
                            select s;
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