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
    public class InvitadosController : ApiController
    {
        private WeddingModel db = new WeddingModel();

        // GET: api/Invitados
        public IQueryable<Invitado> GetInvitado()
        {
            return db.Invitado;
        }

        // GET: api/Invitados/5
        [ResponseType(typeof(Invitado))]
        public IHttpActionResult GetInvitado(int id)
        {
            Invitado invitado = db.Invitado.Find(id);
            if (invitado == null)
            {
                return NotFound();
            }

            return Ok(invitado);
        }

        // PUT: api/Invitados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInvitado(int id, Invitado invitado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitado.InvitadoID)
            {
                return BadRequest();
            }

            db.Entry(invitado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitadoExists(id))
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

        // POST: api/Invitados
        [ResponseType(typeof(Invitado))]
        public IHttpActionResult PostInvitado(Invitado invitado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Invitado.Add(invitado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = invitado.InvitadoID }, invitado);
        }

        // DELETE: api/Invitados/5
        [ResponseType(typeof(Invitado))]
        public IHttpActionResult DeleteInvitado(int id)
        {
            Invitado invitado = db.Invitado.Find(id);
            if (invitado == null)
            {
                return NotFound();
            }

            db.Invitado.Remove(invitado);
            db.SaveChanges();

            return Ok(invitado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvitadoExists(int id)
        {
            return db.Invitado.Count(e => e.InvitadoID == id) > 0;
        }
    }
}