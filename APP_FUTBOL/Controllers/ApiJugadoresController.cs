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
    public class ApiJugadoresController : ApiController
    {
        private SoccerTotalEntities db = new SoccerTotalEntities();

        // GET: api/ApiJugadores
        public IQueryable<Cat_Jugador> GetCat_Jugador()
        {
            return db.Cat_Jugador;
        }

        // GET: api/ApiJugadores/5
        [ResponseType(typeof(Cat_Jugador))]
        public IHttpActionResult GetCat_Jugador(int id)
        {
            Cat_Jugador cat_Jugador = db.Cat_Jugador.Find(id);
            if (cat_Jugador == null)
            {
                return NotFound();
            }

            return Ok(cat_Jugador);
        }

        // PUT: api/ApiJugadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCat_Jugador(int id, Cat_Jugador cat_Jugador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cat_Jugador.id)
            {
                return BadRequest();
            }

            db.Entry(cat_Jugador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cat_JugadorExists(id))
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

        // POST: api/ApiJugadores
        [ResponseType(typeof(Cat_Jugador))]
        public IHttpActionResult PostCat_Jugador(Cat_Jugador cat_Jugador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cat_Jugador.Add(cat_Jugador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cat_Jugador.id }, cat_Jugador);
        }

        // DELETE: api/ApiJugadores/5
        [ResponseType(typeof(Cat_Jugador))]
        public IHttpActionResult DeleteCat_Jugador(int id)
        {
            Cat_Jugador cat_Jugador = db.Cat_Jugador.Find(id);
            if (cat_Jugador == null)
            {
                return NotFound();
            }

            db.Cat_Jugador.Remove(cat_Jugador);
            db.SaveChanges();

            return Ok(cat_Jugador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Cat_JugadorExists(int id)
        {
            return db.Cat_Jugador.Count(e => e.id == id) > 0;
        }
    }
}