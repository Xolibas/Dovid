using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dovid.Models;

namespace Dovid.Controllers
{
    public class AddController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Add
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Train train)
        {
            if (train.SPos == null || train.FPos == null || train.STime == null || train.FTime == null || train.VCount == 0 || train.Price == 0)
            {
                Response.Write("<script>window.alert('Заповніть всі поля!');</script>");
                return View();
            }
            else
            {
                db.Trains.Add(train);
                db.SaveChanges();
                return RedirectToAction("../home/");
            }
        }
    }
}