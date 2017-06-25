using AutoCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoCatalog.Models
{
    public class Car
    {
        public int Id { get; set; }
        public int? MarkId { get; set; }
        public Mark Mark { get; set; }
        public int? ModelId { get; set; }
        public Model Model { get; set; }
        public int? ColorId { get; set; }
        public Color Color { get; set; }
        public int? EngineID { get; set; }
        public Engine Engine { get; set; }
        public int? PriceID { get; set; }
        public Price Price { get; set; }
        public string Description { get; set; }

    }



    public class Mark
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Mark()
        {
            Cars = new List<Car>();
        }
    }

    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Model()
        {
            Cars = new List<Car>();
        }
    }

    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Color()
        {
            Cars = new List<Car>();
        }
    }

    public class Engine
    {
        public int Id { get; set; }
        public double enginetype { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Engine()
        {
            Cars = new List<Car>();
        }
    }

    public class Price
    {
        public int Id { get; set; }
        public int previousPrice { get; set; }
        public int currentPrice { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Price()
        {
            Cars = new List<Car>();
        }
    }

    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public SelectList Marks { get; set; }
        public SelectList Colors { get; set; }
        public SelectList Engines { get; set; }
    
    }
}