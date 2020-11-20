using AirBookings.DataAccess;
using AirBookings.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            GetFile();
            return View(db.Seats);
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

        [HttpGet]
        public ActionResult Buy(int id = 0)
        {
            ViewBag.BookingSeatId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Booking purchase)
        {
            purchase.Id = db.Bookings.ToArray().Length + 1;
            purchase.FlightId = 1;
            db.Bookings.Add(purchase);
            db.SaveChanges();
            return "Спасибо, " + purchase.PassengerName + ", за покупку!";
         }

        public string Square(double a, double b)
        {
            double s = a * b;
            return "<h2>Площадь прямоугольника со сторонами " + a +
            " и " + b + " равна " + s + "</h2>";
        }

        public FileResult GetFile()
        {
            string path = Server.MapPath("~/App_Data/Price.xlsx");
            return File(path, "application/xlsx", "Price.xlsx");
        }
    }
}