using Dovid.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dovid.Controllers
{
    public class StationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            IEnumerable<Station> stations = db.Stations;

            ViewBag.Stations = stations;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Station station)
        {
            if (station.Name == null || station.Oblast == null )
            {
                Response.Write("<script>window.alert('Заповніть всі поля!');</script>");
                return View();
            }
            else
            {
                db.Stations.Add(station);
                db.SaveChanges();
                return RedirectToAction("../home/");
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Station station = db.Stations.Find(id);
            ViewBag.Trains = db.Trains.ToList();
            if (station != null)
            {
                return View(station);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Station station, int[] selectedTrains)
        {
            Station newStation = db.Stations.Find(station.Id);
            newStation.Name = station.Name;
            newStation.Oblast = station.Oblast;
            newStation.Trains.Clear();
            if (selectedTrains != null)
            {
                //отримуємо вибрані курси
                foreach (var t in db.Trains.Where(co =>
               selectedTrains.Contains(co.Id)))
                {
                    newStation.Trains.Add(t);
                }
            }
            db.Entry(newStation).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Station b = db.Stations.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Station s = db.Stations.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            db.Stations.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}