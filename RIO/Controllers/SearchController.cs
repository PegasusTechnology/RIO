using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RIO.Models;

namespace RIO.Controllers
{
    public class SearchController : Controller
    {
        private RIOContext db = new RIOContext();

        //
        // GET: /Search/

        public ActionResult Index(string itemName = null, string category = null)
        {
            SearchViewModel model = new SearchViewModel();
            model.Categories = db.Category.AsEnumerable();
            int categoryId = Convert.ToInt32(((string.IsNullOrEmpty(category)) ? null : category));
            model.Items = db.Item.Where(p => p.ItemName.Contains(itemName) &&
                (p.CategoryId == categoryId || category == string.Empty));

            return View(model);
        }

        //
        // GET: /Search/Details/5

        public ActionResult Details(int id = 0)
        {
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /Search/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");
            ViewBag.BrandId = new SelectList(db.Brand, "BrandId", "BrandName");
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "AddressLine1");
            return View();
        }

        //
        // POST: /Search/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Item.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", item.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brand, "BrandId", "BrandName", item.BrandId);
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "AddressLine1", item.AddressId);
            return View(item);
        }

        //
        // GET: /Search/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", item.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brand, "BrandId", "BrandName", item.BrandId);
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "AddressLine1", item.AddressId);
            return View(item);
        }

        //
        // POST: /Search/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", item.CategoryId);
            ViewBag.BrandId = new SelectList(db.Brand, "BrandId", "BrandName", item.BrandId);
            ViewBag.AddressId = new SelectList(db.Address, "AddressId", "AddressLine1", item.AddressId);
            return View(item);
        }

        //
        // GET: /Search/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Item item = db.Item.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /Search/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Item.Find(id);
            db.Item.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}