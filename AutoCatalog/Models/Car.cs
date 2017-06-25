using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoCatalog.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


    }
}