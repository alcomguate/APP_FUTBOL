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
    public class JugadoresController : Controller
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: Jugadores
        public ActionResult Index()
        {
            var cat_Jugador = db.Cat_Jugador.Include(c => c.Cat_Equipo);
            return View(cat_Jugador.ToList());
        }

        public ActionResult Index(int equipo)
        {
            var cat_jugador = db.Cat_Jugador.Where(x => x.equipo == equipo);
            return View(cat_jugador.ToList());
        }

        // GET: Jugadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Jugador cat_Jugador = db.Cat_Jugador.Find(id);
            if (cat_Jugador == null)
            {
                return HttpNotFound();
            }
            return View(cat_Jugador);
        }

        // GET: Jugadores/Create
        public ActionResult Create()
        {
            ViewBag.equipo = new SelectList(db.Cat_Equipo, "id", "nombre");
            return View();
        }

        // POST: Jugadores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,primer_nombre,segundo_nombre,primer_apellido,segundo_apellido,fec_nacimiento,fec_registro,dorsal,equipo")] Cat_Jugador cat_Jugador)
        {
            if (ModelState.IsValid)
            {
                db.Cat_Jugador.Add(cat_Jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipo = new SelectList(db.Cat_Equipo, "id", "nombre", cat_Jugador.equipo);
            return View(cat_Jugador);
        }

        // GET: Jugadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Jugador cat_Jugador = db.Cat_Jugador.Find(id);
            if (cat_Jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipo = new SelectList(db.Cat_Equipo, "id", "nombre", cat_Jugador.equipo);
            return View(cat_Jugador);
        }

        // POST: Jugadores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,primer_nombre,segundo_nombre,primer_apellido,segundo_apellido,fec_nacimiento,fec_registro,dorsal,equipo")] Cat_Jugador cat_Jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_Jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipo = new SelectList(db.Cat_Equipo, "id", "nombre", cat_Jugador.equipo);
            return View(cat_Jugador);
        }

        // GET: Jugadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cat_Jugador cat_Jugador = db.Cat_Jugador.Find(id);
            if (cat_Jugador == null)
            {
                return HttpNotFound();
            }
            return View(cat_Jugador);
        }

        // POST: Jugadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cat_Jugador cat_Jugador = db.Cat_Jugador.Find(id);
            db.Cat_Jugador.Remove(cat_Jugador);
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
