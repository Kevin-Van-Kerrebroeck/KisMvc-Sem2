using Project_WerkenMetDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Project_WerkenMetDatabase.Models.ViewModels;
using System.Net;

namespace Project_WerkenMetDatabase.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            SeedData sd = new SeedData();

            if(!db.Categories.Any() && !db.Nominees.Any())
            {
                sd.RunSeed();
            }
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
            var vCategories = db.Categories.Include(c=> c.Nominees).ToList();
            return View(vCategories);
        }

        public ActionResult Nominees()
        {
            var Nominees = db.Nominees
                .Include(n => n.Category)
                .OrderBy(n => n.OscarYear)
                .ThenBy(n => n.CategoryId);

            return View(Nominees.ToList());
        }

        public ActionResult CategoriesFilter()
        {
            CategoryFilterViewModel vView = new CategoryFilterViewModel();
            vView.CategoryDropDownList = new SelectList(db.Categories, "id", "CategoryName");
            //vView.Nominees = new List<Nominee>();
            vView.Category = db.Categories.Include(c=> c.Nominees).First();

            return View(vView);
        }

        [HttpPost]
        public ActionResult CategoriesFilter(CategoryFilterViewModel vView)
        {
            vView.CategoryDropDownList = new SelectList(db.Categories, "id", "CategoryName");
            vView.Category = db.Categories.Include(c => c.Nominees).SingleOrDefault(c => c.Id == vView.SelectedId);
            if (vView.Category == null)
            {
                return new HttpNotFoundResult();
            }

            return View(vView);
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