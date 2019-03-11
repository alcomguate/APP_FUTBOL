using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APP_FUTBOL.Models;

namespace APP_FUTBOL.Controllers
{
    public class ApiEquiposController : ApiController
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: api/ApiEquipos
        public IQueryable<Cat_Equipo> GetCat_Equipo()
        {
            return db.Cat_Equipo;
        }

        // GET: api/ApiEquipos/5
        [ResponseType(typeof(Cat_Equipo))]
        public IHttpActionResult GetCat_Equipo(int id)
        {
            Cat_Equipo cat_Equipo = db.Cat_Equipo.Find(id);
            if (cat_Equipo == null)
            {
                return NotFound();
            }

            return Ok(cat_Equipo);
        }

        // PUT: api/ApiEquipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCat_Equipo(int id, Cat_Equipo cat_Equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cat_Equipo.id)
            {
                return BadRequest();
            }

            db.Entry(cat_Equipo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cat_EquipoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiEquipos
        [ResponseType(typeof(Cat_Equipo))]
        public IHttpActionResult PostCat_Equipo(Cat_Equipo cat_Equipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cat_Equipo.Add(cat_Equipo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cat_Equipo.id }, cat_Equipo);
        }

        // DELETE: api/ApiEquipos/5
        [ResponseType(typeof(Cat_Equipo))]
        public IHttpActionResult DeleteCat_Equipo(int id)
        {
            Cat_Equipo cat_Equipo = db.Cat_Equipo.Find(id);
            if (cat_Equipo == null)
            {
                return NotFound();
            }

            db.Cat_Equipo.Remove(cat_Equipo);
            db.SaveChanges();

            return Ok(cat_Equipo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cat_EquipoExists(int id)
        {
            return db.Cat_Equipo.Count(e => e.id == id) > 0;
        }
    }
}