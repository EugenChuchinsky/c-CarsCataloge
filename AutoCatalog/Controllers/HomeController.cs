﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoCatalog.Models;

namespace AutoCatalog.Controllers
{
    public class HomeController : Controller
    {
        CarContext db = new CarContext();
        public ActionResult Index()
        {
            var cars = db.Cars;
            ViewBag.Cars = cars;
            return View();
        }

       
    }
}