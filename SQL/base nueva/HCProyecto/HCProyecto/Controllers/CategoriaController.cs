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
    public class CategoriaController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Categoria
        public IQueryable<Categoria> GetCategoria()
        {
            return db.Categoria;
        }

        // GET: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult GetCategoria(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categoria/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategoria(int id, Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.IDCategoria)
            {
                return BadRequest();
            }

            db.Entry(categoria).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categoria
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult PostCategoria(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categoria.Add(categoria);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = categoria.IDCategoria }, categoria);
        }

        // DELETE: api/Categoria/5
        [ResponseType(typeof(Categoria))]
        public IHttpActionResult DeleteCategoria(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            db.Categoria.Remove(categoria);
            db.SaveChanges();

            return Ok(categoria);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriaExists(int id)
        {
            return db.Categoria.Count(e => e.IDCategoria == id) > 0;
        }
    }
}