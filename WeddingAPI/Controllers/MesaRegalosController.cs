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
    public class MesaRegalosController : ApiController
    {
        private WeddingModel db = new WeddingModel();

        // GET: api/MesaRegaloes
        public IQueryable<MesaRegalo> GetMesaRegalo()
        {
            return db.MesaRegalo;
        }

        // GET: api/MesaRegaloes/5
        [ResponseType(typeof(MesaRegalo))]
        public IHttpActionResult GetMesaRegalo(int id)
        {
            MesaRegalo mesaRegalo = db.MesaRegalo.Find(id);
            if (mesaRegalo == null)
            {
                return NotFound();
            }

            return Ok(mesaRegalo);
        }

        // PUT: api/MesaRegaloes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMesaRegalo(int id, MesaRegalo mesaRegalo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mesaRegalo.MesaRegaloID)
            {
                return BadRequest();
            }

            db.Entry(mesaRegalo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MesaRegaloExists(id))
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

        // POST: api/MesaRegaloes
        [ResponseType(typeof(MesaRegalo))]
        public IHttpActionResult PostMesaRegalo(MesaRegalo mesaRegalo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MesaRegalo.Add(mesaRegalo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mesaRegalo.MesaRegaloID }, mesaRegalo);
        }

        // DELETE: api/MesaRegaloes/5
        [ResponseType(typeof(MesaRegalo))]
        public IHttpActionResult DeleteMesaRegalo(int id)
        {
            MesaRegalo mesaRegalo = db.MesaRegalo.Find(id);
            if (mesaRegalo == null)
            {
                return NotFound();
            }

            db.MesaRegalo.Remove(mesaRegalo);
            db.SaveChanges();

            return Ok(mesaRegalo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MesaRegaloExists(int id)
        {
            return db.MesaRegalo.Count(e => e.MesaRegaloID == id) > 0;
        }
    }
}