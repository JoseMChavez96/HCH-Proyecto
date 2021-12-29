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
    public class COMPRAController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/COMPRA
        public IQueryable<COMPRA> GetCOMPRA()
        {
            return db.COMPRA;
        }

        // GET: api/COMPRA/5
        [ResponseType(typeof(COMPRA))]
        public IHttpActionResult GetCOMPRA(int id)
        {
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return NotFound();
            }

            return Ok(cOMPRA);
        }

        // PUT: api/COMPRA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOMPRA(int id, COMPRA cOMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOMPRA.IdCompra)
            {
                return BadRequest();
            }

            db.Entry(cOMPRA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COMPRAExists(id))
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

        // POST: api/COMPRA
        [ResponseType(typeof(COMPRA))]
        public IHttpActionResult PostCOMPRA(COMPRA cOMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COMPRA.Add(cOMPRA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cOMPRA.IdCompra }, cOMPRA);
        }

        // DELETE: api/COMPRA/5
        [ResponseType(typeof(COMPRA))]
        public IHttpActionResult DeleteCOMPRA(int id)
        {
            COMPRA cOMPRA = db.COMPRA.Find(id);
            if (cOMPRA == null)
            {
                return NotFound();
            }

            db.COMPRA.Remove(cOMPRA);
            db.SaveChanges();

            return Ok(cOMPRA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COMPRAExists(int id)
        {
            return db.COMPRA.Count(e => e.IdCompra == id) > 0;
        }
    }
}