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
    public class CampeonatosController : Controller
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: Campeonatos
        public ActionResult Index()
        {
            var campeonatoes = db.Campeonatoes.Include(c => c.Cat_Categoria);
            return View(campeonatoes.ToList());
        }

        // GET: Campeonatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonatoes.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // GET: Campeonatos/Create
        public ActionResult Create()
        {
            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion");
            return View();
        }

        // POST: Campeonatos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,inicio,fin,categoria")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                db.Campeonatoes.Add(campeonato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion", campeonato.categoria);
            return View(campeonato);
        }

        // GET: Campeonatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonatoes.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion", campeonato.categoria);
            return View(campeonato);
        }

        // POST: Campeonatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,inicio,fin,categoria")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campeonato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoria = new SelectList(db.Cat_Categoria, "id", "descripcion", campeonato.categoria);
            return View(campeonato);
        }

        // GET: Campeonatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonatoes.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // POST: Campeonatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campeonato campeonato = db.Campeonatoes.Find(id);
            db.Campeonatoes.Remove(campeonato);
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
