using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCatalog.Models;
using System.Data.Entity;

namespace AutoCatalog.Controllers
{
    public class HomeController : Controller
    {
        CarContext db = new CarContext();
        public ActionResult Index()
        {
            var cars = db.Cars;

            //ViewBag.Cars = cars;

            return View(cars);
        }

        public ActionResult CarIndex()
        {
            var cars = db.Cars;

            //ViewBag.Cars = cars;

            return View(cars);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditCar(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                return View(car);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            db.Entry(car).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Car b = db.Cars.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Car b = db.Cars.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Cars.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}