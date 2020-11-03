using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dovid.Models;
using System.Data.Entity;
namespace Dovid.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            IEnumerable<Train> trains = context.Trains;

            ViewBag.Trains = trains;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Train train = context.Trains.Find(id);
            ViewBag.Stations = context.Stations.ToList();
            if (train != null)
            {
                return View(train);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Train train, int[] selectedStations)
        {
            Train newTrain = context.Trains.Find(train.Id);
            newTrain.SPos = train.SPos;
            newTrain.FPos = train.FPos;
            newTrain.STime = train.STime;
            newTrain.FTime = train.FTime;
            newTrain.VCount = train.VCount;
            newTrain.Price = train.Price;
            newTrain.Stations.Clear();
            if (selectedStations != null)
            {
                //отримуємо вибрані курси
                foreach (var c in context.Stations.Where(co =>
               selectedStations.Contains(co.Id)))
                {
                newTrain.Stations.Add(c);
                }
            }
            context.Entry(newTrain).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Train b = context.Trains.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Train b = context.Trains.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            context.Trains.Remove(b);
            context.SaveChanges();
            return RedirectToAction("Index");
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
    }
}