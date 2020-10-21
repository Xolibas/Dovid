using Dovid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Dovid.Controllers
{
    public class TicketController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Buy
        int Pid;
        [HttpGet]
        public ActionResult Buy(int id)
        {
            Pid = id;
            ViewBag.ProductId = Pid;
            Train train = context.Trains.Find(id);
            if (train != null)
            {
                return View(train);
            }
            return View("Buy");
        }
        [HttpPost]
        public string Buy(Ticket ticket)
        {
            ticket.Date = DateTime.Now;

            context.Tickets.Add(ticket);

            context.SaveChanges();
            Train train = context.Trains.Find(Pid);
            return "Дякую," + ticket.Name + " " + ticket.Sname + ", за замовлення білету на потяг!";

        }
    }
}