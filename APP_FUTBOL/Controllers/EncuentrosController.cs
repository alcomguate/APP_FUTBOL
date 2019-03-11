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
    public class EncuentrosController : Controller
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: Encuentros
        public ActionResult Index()
        {
            var encuentroes = db.Encuentroes.Include(e => e.Campeonato1).Include(e => e.Cat_Equipo).Include(e => e.Cat_Equipo1);
            return View(encuentroes.ToList());
        }

        // GET: Encuentros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuentro encuentro = db.Encuentroes.Find(id);
            if (encuentro == null)
            {
                return HttpNotFound();
            }
            return View(encuentro);
        }

        // GET: Encuentros/Create
        public ActionResult Create()
        {
            ViewBag.campeonato = new SelectList(db.Campeonatoes, "id", "id");
            ViewBag.equipo_local = new SelectList(db.Cat_Equipo, "id", "nombre");
            ViewBag.equipo_visita = new SelectList(db.Cat_Equipo, "id", "nombre");
            return View();
        }

        // POST: Encuentros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fec_encuentro,hora_encuentro,numero_campo,campeonato,equipo_local,equipo_visita,goles_local,goles_visita")] Encuentro encuentro)
        {
            if (encuentro.equipo_local == encuentro.equipo_visita) {
                return View(encuentro);
            }
            if (ModelState.IsValid)
            {
                encuentro.finalizado = false;
                encuentro.goles_local = 0;
                encuentro.goles_visita = 0;
                db.Encuentroes.Add(encuentro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.campeonato = new SelectList(db.Campeonatoes, "id", "id", encuentro.campeonato);
            ViewBag.equipo_local = new SelectList(db.Cat_Equipo, "id", "nombre", encuentro.equipo_local);
            ViewBag.equipo_visita = new SelectList(db.Cat_Equipo, "id", "nombre", encuentro.equipo_visita);
            return View(encuentro);
        }

        // GET: Encuentros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuentro encuentro = db.Encuentroes.Find(id);
            if (encuentro == null)
            {
                return HttpNotFound();
            }
            ViewBag.campeonato = new SelectList(db.Campeonatoes, "id", "id", encuentro.campeonato);
            ViewBag.equipo_local = new SelectList(db.Cat_Equipo, "id", "nombre", encuentro.equipo_local);
            ViewBag.equipo_visita = new SelectList(db.Cat_Equipo, "id", "nombre", encuentro.equipo_visita);
            return View(encuentro);
        }

        // POST: Encuentros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fec_encuentro,hora_encuentro,numero_campo,campeonato,equipo_local,equipo_visita,goles_local,goles_visita")] Encuentro encuentro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuentro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.campeonato = new SelectList(db.Campeonatoes, "id", "id", encuentro.campeonato);
            ViewBag.equipo_local = new SelectList(db.Cat_Equipo, "id", "nombre", encuentro.equipo_local);
            ViewBag.equipo_visita = new SelectList(db.Cat_Equipo, "id", "nombre", encuentro.equipo_visita);
            return View(encuentro);
        }

        // GET: Encuentros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuentro encuentro = db.Encuentroes.Find(id);
            if (encuentro == null)
            {
                return HttpNotFound();
            }
            return View(encuentro);
        }

        // POST: Encuentros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encuentro encuentro = db.Encuentroes.Find(id);
            db.Encuentroes.Remove(encuentro);
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
