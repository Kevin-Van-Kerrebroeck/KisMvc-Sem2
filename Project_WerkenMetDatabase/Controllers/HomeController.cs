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

        public ActionResult Index(string sortOrder)
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

        public ActionResult About()
        {
            //Ophalen van file naam
            string vFullFileName = Server.MapPath("/Data/TestData.txt");

            //Lees de inhoud van de File
            string[] vInhoud = System.IO.File.ReadAllLines(vFullFileName);

            //Viewbaggen
            foreach (string line in vInhoud)
            {
                ViewBag.Info += line + "<br/>";
            }
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}