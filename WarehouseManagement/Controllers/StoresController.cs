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
using System.Data.Entity.Spatial;
using System.Globalization;

namespace WarehouseManagement.Controllers
{
    public class StoresController : Controller
    {
        private WarehouseContext db = new WarehouseContext();

        // GET: Stores
        public ActionResult Index(string Category, string NameString, string Budget)
        {
            int price = 0;
            var CategoryLst = new List<String>();
            var CategoryQry = from d in db.Stores
                              group d by d.Purpose into g
                              select g.Key ;

          //  CategoryLst.AddRange(CategoryQry.);
            ViewBag.Category = new SelectList(CategoryQry);

            var Stores = from s in db.Stores
                         select s;

            if (!String.IsNullOrWhiteSpace(NameString))

            {
                Stores = Stores.Where(s => (s.Name.Contains(NameString))
                            );

            }
            if (!string.IsNullOrEmpty(Category))
            {
                Stores = Stores.Where(x => x.Purpose == Category);
            }

            if (!String.IsNullOrWhiteSpace(Budget))
            {
                price = int.Parse(Budget);

                Stores = Stores.Where(s => (s.Budget > price)
                            );

            }

            return View(Stores);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Purpose,Budget,Address,Location")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Purpose,Budget,Address,Location")] Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store store = db.Stores.Find(id);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
    }
}
