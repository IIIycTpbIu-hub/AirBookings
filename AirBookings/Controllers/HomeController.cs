using AirBookings.DataAccess;
using AirBookings.Models;
using AirBookings.Models.Pageing;
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
        Lab3Context db2 = new Lab3Context();
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

        public ActionResult PageView(int page = 1)
        {
            var products = db2.Products.Include("Employee").ToList();
            int pageSize = 5;
            var productsOnPage = products.Skip((page - 1) * pageSize).Take(pageSize);
            PagePag pag = new PagePag { PageNumber = page, PageSize = pageSize, TotalProducts = products.Count };
            ViewProducts viewProducts = new ViewProducts { PagePag = pag, Products = productsOnPage};
            return View(viewProducts);
        }

        public ActionResult GetDirections()
        {
            ViewBag.Message = "Доступные направления";

            return PartialView(db.Flights);
        }

        public ActionResult GetProducts()
        {
            var products = db2.Products.Include("Employee");
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList empl = new SelectList(db2.Employees, "Id", "Name");
            ViewBag.Employees = empl;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            product.Employee.Position = "";
            db2.Products.Add(product);
            db2.SaveChanges();
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db2.Products.Find(id);
            if(product != null)
            {
                SelectList empl = new SelectList(db2.Employees, "Id", "Name", product.EmployeeId);
                ViewBag.Employees = empl;
                return View(product);
            }
            return RedirectToAction("GetProducts");
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            db2.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db2.SaveChanges();
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db2.Products.Find(id);
            if (product != null)
            {
                SelectList empl = new SelectList(db2.Employees, "Id", "Name", product.EmployeeId);
                ViewBag.Employees = empl;
                return View(product);
            }
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = db2.Products.Find(id);
            if(product != null)
            {
                db2.Products.Remove(product);
                db2.SaveChanges();
            }
            return RedirectToAction("GetProducts");
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