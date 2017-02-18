using Project_WerkenMetDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_WerkenMetDatabase.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Presidents(string sortOrder)
        {
            var Presidents = db.Presidents.ToList().OrderBy(p => p.StartDate);

            switch (sortOrder)
            {
                case "sortByID":
                    Presidents = Presidents.OrderBy(p => p.Id);
                    break;
                case "sortByName":
                    Presidents = Presidents.OrderBy(p => p.Name);
                    break;
                case "sortByDate":
                    Presidents = Presidents.OrderBy(p => p.StartDate);
                    break;
                default:
                    Presidents = Presidents.OrderBy(p => p.StartDate);
                    break;
            }
            
            return View(Presidents);
        }

        public ActionResult Categories()
        {
           
            return View(db.Categories.ToList());
        }

        public ActionResult Nominees()
        {
            

            return View(db.Nominees.ToList());
        }

        public ActionResult RunSeed()
        {
            ViewBag.Info = new SeedData().RunSeed();
            return View();
        }

        public ActionResult RunSeedRemove()
        {
            var sd = new SeedData();

            sd.RemoveSeedData<President>();
            sd.RemoveSeedData<Nominee>();
            sd.RemoveSeedData<Category>();

            ViewBag.Info = "Data byebye";
            return View();
        }


    }
}