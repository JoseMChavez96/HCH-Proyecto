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
using HCProyecto.Models;

namespace HCProyecto.Controllers
{
    public class MarcaController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Marca
        public IQueryable<Marca> GetMarca()
        {
            return db.Marca;
        }

        // GET: api/Marca/5
        [ResponseType(typeof(Marca))]
        public IHttpActionResult GetMarca(int id)
        {
            Marca marca = db.Marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        // PUT: api/Marca/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMarca(int id, Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.IDMarca)
            {
                return BadRequest();
            }

            db.Entry(marca).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marca
        [ResponseType(typeof(Marca))]
        public IHttpActionResult PostMarca(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Marca.Add(marca);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marca.IDMarca }, marca);
        }

        // DELETE: api/Marca/5
        [ResponseType(typeof(Marca))]
        public IHttpActionResult DeleteMarca(int id)
        {
            Marca marca = db.Marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            db.Marca.Remove(marca);
            db.SaveChanges();

            return Ok(marca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MarcaExists(int id)
        {
            return db.Marca.Count(e => e.IDMarca == id) > 0;
        }
    }
}