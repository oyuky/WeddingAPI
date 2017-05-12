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
    public class InvitacionesController : ApiController
    {
        private WeddingModel db = new WeddingModel();

        // GET: api/Invitaciones
        public IQueryable<Invitacion> GetInvitacion()
        {
            return db.Invitacion;
        }

        // GET: api/Invitaciones/5
        [ResponseType(typeof(Invitacion))]
        public IHttpActionResult GetInvitacion(int id)
        {
            Invitacion invitacion = db.Invitacion.Find(id);
            if (invitacion == null)
            {
                return NotFound();
            }

            return Ok(invitacion);
        }

        // PUT: api/Invitaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvitacion(int id, Invitacion invitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitacion.InvitacionID)
            {
                return BadRequest();
            }

            db.Entry(invitacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitacionExists(id))
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

        // POST: api/Invitaciones
        [ResponseType(typeof(Invitacion))]
        public IHttpActionResult PostInvitacion(Invitacion invitacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Invitacion.Add(invitacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = invitacion.InvitacionID }, invitacion);
        }

        // DELETE: api/Invitaciones/5
        [ResponseType(typeof(Invitacion))]
        public IHttpActionResult DeleteInvitacion(int id)
        {
            Invitacion invitacion = db.Invitacion.Find(id);
            if (invitacion == null)
            {
                return NotFound();
            }

            db.Invitacion.Remove(invitacion);
            db.SaveChanges();

            return Ok(invitacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvitacionExists(int id)
        {
            return db.Invitacion.Count(e => e.InvitacionID == id) > 0;
        }
    }
}