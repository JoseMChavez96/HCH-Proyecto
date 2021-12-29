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
using dannyprueba.Models;

namespace dannyprueba.Controllers
{
    public class CATEGORIAController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CATEGORIA
        public IQueryable<CATEGORIA> GetCATEGORIA()
        {
            return db.CATEGORIA;
        }

        // GET: api/CATEGORIA/5
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult GetCATEGORIA(int id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return NotFound();
            }

            return Ok(cATEGORIA);
        }

        // PUT: api/CATEGORIA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCATEGORIA(int id, CATEGORIA cATEGORIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cATEGORIA.IdCategoria)
            {
                return BadRequest();
            }

            db.Entry(cATEGORIA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CATEGORIAExists(id))
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

        // POST: api/CATEGORIA
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult PostCATEGORIA(CATEGORIA cATEGORIA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CATEGORIA.Add(cATEGORIA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cATEGORIA.IdCategoria }, cATEGORIA);
        }

        // DELETE: api/CATEGORIA/5
        [ResponseType(typeof(CATEGORIA))]
        public IHttpActionResult DeleteCATEGORIA(int id)
        {
            CATEGORIA cATEGORIA = db.CATEGORIA.Find(id);
            if (cATEGORIA == null)
            {
                return NotFound();
            }

            db.CATEGORIA.Remove(cATEGORIA);
            db.SaveChanges();

            return Ok(cATEGORIA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CATEGORIAExists(int id)
        {
            return db.CATEGORIA.Count(e => e.IdCategoria == id) > 0;
        }
    }
}