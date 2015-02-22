using RIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RIO.Controllers
{
    public class HomeController : Controller
    {

        private RIOContext db = new RIOContext();

        public ActionResult Index(string itemName = null, string category = null)
        {
            SearchViewModel model = new SearchViewModel();
            model.Categories = db.Category.AsEnumerable();
            int categoryId = Convert.ToInt32(((string.IsNullOrEmpty(category)) ? null : category));
            model.Items = db.Item.Where(p => p.ItemName.Contains(itemName) &&
                (p.CategoryId == categoryId || category == string.Empty) &&
                p.IsActive);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
