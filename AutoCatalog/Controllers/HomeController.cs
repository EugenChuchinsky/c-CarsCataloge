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
        public ActionResult Index(int? mark, int? color, int? engine)
        {
            IQueryable<Car> cars = db.Cars.Include(p => p.Mark);
            if (mark != null && mark != 0)
            {
                cars = cars.Where(p => p.MarkId == mark);
            }
            if (color != null && color != 0)
            {
                cars = cars.Where(p => p.ColorId == color);
            }
            if ( engine != null && engine != 0)
            {
                cars = cars.Where(p => p.EngineID == engine);
            }
            List<Mark> marks = db.Marks.ToList();
            marks.Insert(0, new Mark { Name = "Все", Id = 0 });
            List<Color> colors = db.Colors.ToList();
            colors.Insert(0, new Color { Name = "Все", Id = 0 });
            List<Engine> engines = db.Enigines.ToList();
            engines.Insert(0, new Engine { enginetype = 0, Id = 0 });


            CarListViewModel clv = new CarListViewModel
            {
                Cars = cars.ToList(),
                Marks = new SelectList(marks, "Id", "Name"),
                Colors = new SelectList(colors, "Id", "Name"),
                Engines = new SelectList(engines, "Id", "enginetype")
            };
            return View(clv);
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