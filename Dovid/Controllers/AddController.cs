using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dovid.Models;
using Dovid.Filters;

namespace Dovid.Controllers
{
    [Culture]
    public class AddController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Train train)
        {
            if(!ModelState.IsValid)
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