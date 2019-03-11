using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APP_FUTBOL.Models;

namespace APP_FUTBOL.Controllers
{
    public class CategoriaController : Controller
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: Categoria
        public ActionResult Index()
        {
            return View(db.Cat_Categoria.ToList());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Categoria cat_Categoria = db.Cat_Categoria.Find(id);
            if (cat_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(cat_Categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,activo")] Cat_Categoria cat_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Categoria.Add(cat_Categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cat_Categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Categoria cat_Categoria = db.Cat_Categoria.Find(id);
            if (cat_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(cat_Categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,activo")] Cat_Categoria cat_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat_Categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Categoria cat_Categoria = db.Cat_Categoria.Find(id);
            if (cat_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(cat_Categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Categoria cat_Categoria = db.Cat_Categoria.Find(id);
            db.Cat_Categoria.Remove(cat_Categoria);
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
