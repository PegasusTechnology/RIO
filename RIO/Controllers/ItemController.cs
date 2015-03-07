using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RIO.Models;
using RIO.Models.ViewModels;

namespace RIO.Controllers
{
    public class ItemController : Controller
    {
        private RIOContext db = new RIOContext();

        //
        // GET: /Item/

        public ActionResult Index()
        {
            var item = db.Item.Include(i => i.Category).Include(i => i.Brand).Include(i => i.Address);
            return View(item.ToList());
        }

        //
        // GET: /Item/Details/5

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
        // GET: /Item/Create

        public ActionResult Create()
        {
            ItemCreateViewModel viewModel = new ItemCreateViewModel();

            viewModel.Category = new SelectList(db.Category, "CategoryId", "CategoryName", "SelectedCategoryId");
            viewModel.Brand = new SelectList(db.Brand, "BrandId", "BrandName", "SelectedBrandId");
            viewModel.Address = new SelectList(db.Address, "AddressId", "AddressLine1", "SelectedAddressId");
            viewModel.Costing = new SelectList(db.Costing, "CostingId", "Name", "SelectedCostingId");
            viewModel.IdentityProof = new SelectList(db.Costing, "IdentityProofId", "Name", "SelectedIdentityProofId");

            return View(viewModel);
        }

        //
        // POST: /Item/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Item.Add(viewModel);
                //db.SaveChanges();
                return RedirectToAction("Index", "Home", null);
            }

            viewModel.Category = new SelectList(db.Category, "CategoryId", "CategoryName", "SelectedCategoryId");
            viewModel.Brand = new SelectList(db.Brand, "BrandId", "BrandName", "SelectedBrandId");
            viewModel.Address = new SelectList(db.Address, "AddressId", "AddressLine1", "SelectedAddressId");
            viewModel.Costing = new SelectList(db.Costing, "CostingId", "Name", "SelectedCostingId");
            viewModel.IdentityProof = new SelectList(db.Costing, "IdentityProofId", "Name", "SelectedIdentityProofId");

            return View(viewModel);
        }

        //
        // GET: /Item/Edit/5

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
        // POST: /Item/Edit/5

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
        // GET: /Item/Delete/5

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
        // POST: /Item/Delete/5

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