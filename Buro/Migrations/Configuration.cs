namespace Buro.Migrations
{
    using Buro.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Buro.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Buro.Models.ApplicationDbContext context)
        {
            context.Trains.Add(new Train { SPos = "Хмельницький", FPos = "Київ", STime=Convert.ToDateTime("04-08-2020"), FTime = Convert.ToDateTime("05-08-2020"), VCount = 10, Price = 100 });
            context.Trains.Add(new Train { SPos = "Львів", FPos = "Одеса", STime = Convert.ToDateTime("03-09-2020"), FTime = Convert.ToDateTime("03-09-2020"), VCount = 10, Price = 300 });
            context.Trains.Add(new Train { SPos = "Харків", FPos = "Тернопіль", STime = Convert.ToDateTime("12-12-2020"), FTime = Convert.ToDateTime("13-12-2020"), VCount = 10, Price = 400 });
            context.Trains.Add(new Train { SPos = "Чернівці", FPos = "Луцьк", STime = Convert.ToDateTime("13-11-2020"), FTime = Convert.ToDateTime("13-11-2020"), VCount = 10, Price = 100 });
        }
    }
}
