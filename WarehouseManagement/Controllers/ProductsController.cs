using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarehouseManagement.DAL;
using WarehouseManagement.Models;

namespace WarehouseManagement.Controllers
{
    public class ProductsController : Controller
    {

        private WarehouseContext db = new WarehouseContext();

        //search
        public ActionResult Index(string Productprice, string NameString, string Productwarehouse)
        {

            ViewBag.Struct =
                            (from i in db.Products
                             join o in db.Products on i.Warehouses.Address equals o.Stores.Address
                             select i.Name).ToList();



            ////////////////////////////////////////////////
            int price = 0;
            var WarehouseLst = new List<String>();
            var WarehoseQry = from d in db.Products
                           orderby d.Warehouses.Name
                           select d.Warehouses.Name;

        WarehouseLst.AddRange(WarehoseQry.Distinct());
        ViewBag.Productwarehouse = new SelectList(WarehouseLst);


            var Products = from s in db.Products
                               select s;

            if (!String.IsNullOrWhiteSpace(NameString))
                     
                  {
                Products = Products.Where(s => (s.Name.Contains(NameString))  
                            );

                  }
            if (!string.IsNullOrEmpty(Productwarehouse))
            {
                Products = Products.Where(x => x.Warehouses.Name == Productwarehouse);
            }

            if (!String.IsNullOrWhiteSpace(Productprice))
            {
                price = int.Parse(Productprice);

                Products = Products.Where(s => (s.Price > price)
                            );

            }

            return View(Products);
              }
     

       /* public ActionResult Index(ProductSearchModel searchModel)
        {
            var business = new ProductBusinessLogic();
            var model = business.GetProducts(searchModel);
            return View(model);
        }

*/
        // GET: Products
        public ActionResult Search([Bind(Include = "ProductID,Name,Price,StorageDate,SaleDate,SoldDate,StoreID,WarehouseID")] Product product)
        {
 /*
            var Products = from s in db.Products
                           select s;
            if (!String.IsNullOrEmpty(Productname))
            {
                Products = Products.Where(
                    s => 
                (s.Name==null || s.Name.Contains(Productname))&&
                (s.Price.Equals(0) || s.Price.Equals(Productprice))&&
                (s.WarehouseID == null || s.WarehouseID.Equals(Poductwarehouse))
                                     );
            }
            */
            return View();
        }





        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name");
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "ID", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,Price,StorageDate,SaleDate,SoldDate,StoreID,WarehouseID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", product.StoreID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "ID", "Name", product.WarehouseID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", product.StoreID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "ID", "Name", product.WarehouseID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,Price,StorageDate,SaleDate,SoldDate,StoreID,WarehouseID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreID = new SelectList(db.Stores, "ID", "Name", product.StoreID);
            ViewBag.WarehouseID = new SelectList(db.Warehouses, "ID", "Name", product.WarehouseID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Guest()
        {


            var Products = from s in db.Products
                           select s;


            return View(Products);
        }

    }
}
