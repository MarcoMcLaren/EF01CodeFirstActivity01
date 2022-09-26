using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassActivity.Models;

namespace ClassActivity.Controllers
{
    public class NewModelsController : Controller
    {
        private ListDbContext db = new ListDbContext();

        // GET: NewModels
        public ActionResult Index()
        {
            return View(db.NewModels.ToList());
        }

        // GET: NewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewModel newModel = db.NewModels.Find(id);
            if (newModel == null)
            {
                return HttpNotFound();
            }
            return View(newModel);
        }

        // GET: NewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewModelId,Description")] NewModel newModel)
        {
            if (ModelState.IsValid)
            {
                db.NewModels.Add(newModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newModel);
        }

        // GET: NewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewModel newModel = db.NewModels.Find(id);
            if (newModel == null)
            {
                return HttpNotFound();
            }
            return View(newModel);
        }

        // POST: NewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewModelId,Description")] NewModel newModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newModel);
        }

        // GET: NewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewModel newModel = db.NewModels.Find(id);
            if (newModel == null)
            {
                return HttpNotFound();
            }
            return View(newModel);
        }

        // POST: NewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewModel newModel = db.NewModels.Find(id);
            db.NewModels.Remove(newModel);
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
