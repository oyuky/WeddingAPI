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
using WeddingAPI.Models;

namespace WeddingAPI.Controllers
{
    public class PuntoInteresController : ApiController
    {
        private WeddingModel db = new WeddingModel();

        // GET: api/PuntoInteres
        public IQueryable<PuntoInteres> GetPuntoInteres()
        {
            return db.PuntoInteres;
        }

        // GET: api/PuntoInteres/5
        [ResponseType(typeof(PuntoInteres))]
        public IHttpActionResult GetPuntoInteres(int id)
        {
            PuntoInteres puntoInteres = db.PuntoInteres.Find(id);
            if (puntoInteres == null)
            {
                return NotFound();
            }

            return Ok(puntoInteres);
        }

        // PUT: api/PuntoInteres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPuntoInteres(int id, PuntoInteres puntoInteres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puntoInteres.PuntoInteresID)
            {
                return BadRequest();
            }

            db.Entry(puntoInteres).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuntoInteresExists(id))
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

        // POST: api/PuntoInteres
        [ResponseType(typeof(PuntoInteres))]
        public IHttpActionResult PostPuntoInteres(PuntoInteres puntoInteres)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PuntoInteres.Add(puntoInteres);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = puntoInteres.PuntoInteresID }, puntoInteres);
        }

        // DELETE: api/PuntoInteres/5
        [ResponseType(typeof(PuntoInteres))]
        public IHttpActionResult DeletePuntoInteres(int id)
        {
            PuntoInteres puntoInteres = db.PuntoInteres.Find(id);
            if (puntoInteres == null)
            {
                return NotFound();
            }

            db.PuntoInteres.Remove(puntoInteres);
            db.SaveChanges();

            return Ok(puntoInteres);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PuntoInteresExists(int id)
        {
            return db.PuntoInteres.Count(e => e.PuntoInteresID == id) > 0;
        }
    }
}