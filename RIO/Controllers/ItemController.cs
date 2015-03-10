using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RIO.Models;
using RIO.Models.ViewModels;
using System.Configuration;
using RIO.Helpers;
using System.IO;
using System.Web.Helpers;

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
            viewModel.IdentityProof = db.IdentityProof;

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
                // Initializes the new item object
                Item item = new Item();

                // Logic for uploading image
                if (viewModel.Image != null)
                {
                    // Gets the root upload directory
                    string uploadFolder = Server.MapPath(ConfigurationHelper.UploadFolder);

                    // Creates directory if doesn't exist
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    // Generates unique file name by using Guid
                    string fileName = string.Concat(Guid.NewGuid(), "_", viewModel.Image.FileName);
                    // Concatenates root upload folder and file name
                    string filePath = string.Concat(uploadFolder, fileName);
                    // Saves image to the path
                    viewModel.Image.SaveAs(filePath);
                    // Sets image path to view model
                    viewModel.ImagePath = string.Concat(ConfigurationHelper.UploadFolder, fileName);
                    // Initializes item images object
                    item.Images = new List<ItemImage>();
                    // Adds the image to item image collection
                    item.Images.Add(new ItemImage { ImagePath = viewModel.ImagePath });

                    // Logic for thumbnail image which can be used by search page
                    WebImage webImage = new WebImage(viewModel.Image.InputStream);
                    // Resize image
                    webImage.Resize(Convert.ToInt32(ConfigurationHelper.ThumbnailWidth),
                        Convert.ToInt32(ConfigurationHelper.ThumbnailHeight), preserveAspectRatio: true);
                    // Saves Thumbnail
                    webImage.Save(string.Concat(uploadFolder, "Thumbnail_", fileName));
                    // Adds Thumbnail image to item images collection with IsThumbnail flag true
                    item.Images.Add(new ItemImage
                    {
                        ImagePath = string.Concat(ConfigurationHelper.UploadFolder, "Thumbnail_",
                            fileName),
                        IsThumbnail = true
                    });
                }

                // Assign properties from view model to actual item model object
                item.Category = db.Category.FirstOrDefault(p => p.CategoryId == viewModel.SelectedCategoryId);
                item.Brand = db.Brand.FirstOrDefault(p => p.BrandId == viewModel.SelectedBrandId);
                item.Address = db.Address.FirstOrDefault(p => p.AddressId == viewModel.SelectedAddressId);
                item.ItemName = viewModel.ItemName;
                item.ItemDescription = viewModel.ItemDescription;
                item.Phone = viewModel.Phone.Value;

                // Saves Costing
                item.ItemCosting = new List<ItemCosting>();
                item.ItemCosting.Add(new ItemCosting { CostingId = viewModel.SelectedCostingId.Value });

                // Saves ID Proof
                item.RequiredDocuments = new List<ItemRequiredDocument>();

                if (viewModel.SelectedIdentityProofId != null)
                {
                    foreach (int id in viewModel.SelectedIdentityProofId)
                    {
                        item.RequiredDocuments.Add(new ItemRequiredDocument { IdentityProofId = id });
                    }
                }

                // Adds new item to db
                db.Item.Add(item);
                // Save changes
                db.SaveChanges();

                return RedirectToAction("Index", "Home", null);
            }

            viewModel.Category = new SelectList(db.Category, "CategoryId", "CategoryName", "SelectedCategoryId");
            viewModel.Brand = new SelectList(db.Brand, "BrandId", "BrandName", "SelectedBrandId");
            viewModel.Address = new SelectList(db.Address, "AddressId", "AddressLine1", "SelectedAddressId");
            viewModel.Costing = new SelectList(db.Costing, "CostingId", "Name", "SelectedCostingId");
            viewModel.IdentityProof = db.IdentityProof;

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