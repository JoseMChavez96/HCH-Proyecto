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
    public class DETALLE_COMPRAController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/DETALLE_COMPRA
        public IQueryable<DETALLE_COMPRA> GetDETALLE_COMPRA()
        {
            return db.DETALLE_COMPRA;
        }

        // GET: api/DETALLE_COMPRA/5
        [ResponseType(typeof(DETALLE_COMPRA))]
        public IHttpActionResult GetDETALLE_COMPRA(int id)
        {
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return NotFound();
            }

            return Ok(dETALLE_COMPRA);
        }

        // PUT: api/DETALLE_COMPRA/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDETALLE_COMPRA(int id, DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dETALLE_COMPRA.IdDetalleCompra)
            {
                return BadRequest();
            }

            db.Entry(dETALLE_COMPRA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DETALLE_COMPRAExists(id))
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

        // POST: api/DETALLE_COMPRA
        [ResponseType(typeof(DETALLE_COMPRA))]
        public IHttpActionResult PostDETALLE_COMPRA(DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DETALLE_COMPRA.Add(dETALLE_COMPRA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dETALLE_COMPRA.IdDetalleCompra }, dETALLE_COMPRA);
        }

        // DELETE: api/DETALLE_COMPRA/5
        [ResponseType(typeof(DETALLE_COMPRA))]
        public IHttpActionResult DeleteDETALLE_COMPRA(int id)
        {
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return NotFound();
            }

            db.DETALLE_COMPRA.Remove(dETALLE_COMPRA);
            db.SaveChanges();

            return Ok(dETALLE_COMPRA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DETALLE_COMPRAExists(int id)
        {
            return db.DETALLE_COMPRA.Count(e => e.IdDetalleCompra == id) > 0;
        }
    }
}