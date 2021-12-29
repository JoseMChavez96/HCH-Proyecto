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
using HCH___WebApi_v2.Models;

namespace HCH___WebApi_v2.Controllers
{
    public class USUARIOController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/USUARIO
        public IQueryable<USUARIO> GetUSUARIO()
        {
            return db.USUARIO;
        }

        // GET: api/USUARIO/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult GetUSUARIO(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }

        // PUT: api/USUARIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSUARIO(int id, USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIO.IdUsuario)
            {
                return BadRequest();
            }

            db.Entry(uSUARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOExists(id))
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

        // POST: api/USUARIO
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult PostUSUARIO(USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIO.Add(uSUARIO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSUARIO.IdUsuario }, uSUARIO);
        }

        // DELETE: api/USUARIO/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteUSUARIO(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            db.USUARIO.Remove(uSUARIO);
            db.SaveChanges();

            return Ok(uSUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOExists(int id)
        {
            return db.USUARIO.Count(e => e.IdUsuario == id) > 0;
        }
    }
}