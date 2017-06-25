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
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Engine> Enigines { get; set; }
        public DbSet<Price> Prices { get; set; }

    }

    public class CarDbInitializer : CreateDatabaseIfNotExists<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            Mark m1 = new Mark { Name = "Toyota" };
            Mark m2 = new Mark { Name = "Nissan" };
            db.Marks.Add(m1);
            db.Marks.Add(m2);
            db.SaveChanges();
            Model mod1 = new Model { Name = "Corolla" };
            Model mod2 = new Model { Name = "Tiida" };
            Model mod3 = new Model { Name = "Camry" };
            db.Models.Add(mod1);
            db.Models.Add(mod2);
            db.Models.Add(mod3);
            db.SaveChanges();
            Color col1 = new Color { Name = "Red" };
            Color col2 = new Color { Name = "Gold" };
            Color col3 = new Color { Name = "Grey" };
            db.Colors.Add(col1);
            db.Colors.Add(col2);
            db.Colors.Add(col3);
            db.SaveChanges();
            Engine en1 = new Engine { enginetype = 1.2 };
            Engine en2 = new Engine { enginetype = 1.6 };
            Engine en3 = new Engine { enginetype = 1.8 };
            db.Enigines.Add(en1);
            db.Enigines.Add(en2);
            db.Enigines.Add(en3);
            db.SaveChanges();
            Price pr1 = new Price { currentPrice = 20000 };
            Price pr2 = new Price { currentPrice = 18000 };
            Price pr3 = new Price { currentPrice = 28000 };
            db.Prices.Add(pr1);
            db.Prices.Add(pr2);
            db.SaveChanges();
            Car car1 = new Car { Mark = m1, Model = mod1, Color = col2, Engine = en2, Price = pr1, Description = "Лучший выбор для наших дорог" };
            Car car2 = new Car { Mark = m2, Model = mod2, Color = col1, Engine = en1, Price = pr2};
            Car car3 = new Car { Mark = m1, Model = mod3, Color = col3, Engine = en3, Price = pr3, Description = "Мечта автомобилиста" };
            db.Cars.AddRange(new List<Car> { car1, car2, car3 });
            db.SaveChanges();
        }
    }
}