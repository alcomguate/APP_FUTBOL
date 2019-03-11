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
    public class EquiposController : Controller
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: Equipos
        public ActionResult Index()
        {
            var cat_Equipo = db.Cat_Equipo.Include(c => c.Cat_Categoria);
            return View(cat_Equipo.ToList());
        }

        // GET: Equipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Equipo cat_Equipo = db.Cat_Equipo.Find(id);
            if (cat_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(cat_Equipo);
        }

        // GET: Equipos/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion");
            return View();
        }

        // POST: Equipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,fec_inscripcion,categoria")] Cat_Equipo cat_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Equipo.Add(cat_Equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion", cat_Equipo.categoria);
            return View(cat_Equipo);
        }

        // GET: Equipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Equipo cat_Equipo = db.Cat_Equipo.Find(id);
            if (cat_Equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion", cat_Equipo.categoria);
            return View(cat_Equipo);
        }

        // POST: Equipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,fec_inscripcion,categoria")] Cat_Equipo cat_Equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Equipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion", cat_Equipo.categoria);
            return View(cat_Equipo);
        }

        // GET: Equipos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Equipo cat_Equipo = db.Cat_Equipo.Find(id);
            if (cat_Equipo == null)
            {
                return HttpNotFound();
            }
            return View(cat_Equipo);
        }

        // POST: Equipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Equipo cat_Equipo = db.Cat_Equipo.Find(id);
            db.Cat_Equipo.Remove(cat_Equipo);
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
