using INF__440.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INF__440.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Action method for lsiting one random quack from the DB on the landing page
        public ActionResult Index()
        {
            // Taking all qucaks from the DB and adding them to to a list. Only one item from the list will be displayed. 
           return View(db.Quacks.ToList().OrderBy(r => Guid.NewGuid()).Take(1));
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
