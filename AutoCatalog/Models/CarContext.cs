using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoCatalog.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }

    public class CarDbInitializer : CreateDatabaseIfNotExists<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Cars.Add(new Car { Mark = "Toyota", Model = "Corolla", Color = "Grey", Engine = "1,6", Price = 22000, Description = "Grey Vehicle" });
            db.Cars.Add(new Car { Mark = "BMW", Model = "X5", Color = "Black", Engine = "2,2", Price = 52000, Description = "Monster" });
            db.Cars.Add(new Car { Mark = "Nissan", Model = "Tiida", Color = "Gold", Engine = "1,6", Price = 18000 });
            db.Cars.Add(new Car { Mark = "Opel", Model = "Astra", Color = "White", Engine = "1,2", Price = 10000, Description = "Bad choise" });

            base.Seed(db);
        }
    }
}