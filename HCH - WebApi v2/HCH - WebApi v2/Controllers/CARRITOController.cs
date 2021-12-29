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
    public class CARRITOController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/CARRITO
        public IQueryable<CARRITO> GetCARRITO()
        {
            return db.CARRITO;
        }

        // GET: api/CARRITO/5
        [ResponseType(typeof(CARRITO))]
        public IHttpActionResult GetCARRITO(int id)
        {
            CARRITO cARRITO = db.CARRITO.Find(id);
            if (cARRITO == null)
            {
                return NotFound();
            }

            return Ok(cARRITO);
        }

        // PUT: api/CARRITO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCARRITO(int id, CARRITO cARRITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cARRITO.IdCarrito)
            {
                return BadRequest();
            }

            db.Entry(cARRITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CARRITOExists(id))
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

        // POST: api/CARRITO
        [ResponseType(typeof(CARRITO))]
        public IHttpActionResult PostCARRITO(CARRITO cARRITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CARRITO.Add(cARRITO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cARRITO.IdCarrito }, cARRITO);
        }

        // DELETE: api/CARRITO/5
        [ResponseType(typeof(CARRITO))]
        public IHttpActionResult DeleteCARRITO(int id)
        {
            CARRITO cARRITO = db.CARRITO.Find(id);
            if (cARRITO == null)
            {
                return NotFound();
            }

            db.CARRITO.Remove(cARRITO);
            db.SaveChanges();

            return Ok(cARRITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CARRITOExists(int id)
        {
            return db.CARRITO.Count(e => e.IdCarrito == id) > 0;
        }
    }
}