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
    public class MARCAController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/MARCA
        public IQueryable<MARCA> GetMARCA()
        {
            return db.MARCA;
        }

        // GET: api/MARCA/5
        [ResponseType(typeof(MARCA))]
        public IHttpActionResult GetMARCA(int id)
        {
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return NotFound();
            }

            return Ok(mARCA);
        }

        // PUT: api/MARCA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMARCA(int id, MARCA mARCA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mARCA.IdMarca)
            {
                return BadRequest();
            }

            db.Entry(mARCA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MARCAExists(id))
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

        // POST: api/MARCA
        [ResponseType(typeof(MARCA))]
        public IHttpActionResult PostMARCA(MARCA mARCA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MARCA.Add(mARCA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mARCA.IdMarca }, mARCA);
        }

        // DELETE: api/MARCA/5
        [ResponseType(typeof(MARCA))]
        public IHttpActionResult DeleteMARCA(int id)
        {
            MARCA mARCA = db.MARCA.Find(id);
            if (mARCA == null)
            {
                return NotFound();
            }

            db.MARCA.Remove(mARCA);
            db.SaveChanges();

            return Ok(mARCA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MARCAExists(int id)
        {
            return db.MARCA.Count(e => e.IdMarca == id) > 0;
        }
    }
}