using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HCH___WebAPI.Models;

namespace HCH___WebAPI.Controllers
{
    public class DETALLE_COMPRAController : Controller
    {
        private Modelo_HCH db = new Modelo_HCH();

        // GET: DETALLE_COMPRA
        public ActionResult Index()
        {
            var dETALLE_COMPRA = db.DETALLE_COMPRA.Include(d => d.COMPRA).Include(d => d.PRODUCTO);
            return View(dETALLE_COMPRA.ToList());
        }

        // GET: DETALLE_COMPRA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_COMPRA);
        }

        // GET: DETALLE_COMPRA/Create
        public ActionResult Create()
        {
            ViewBag.IdCompra = new SelectList(db.COMPRAs, "IdCompra", "Contacto");
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre");
            return View();
        }

        // POST: DETALLE_COMPRA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetalleCompra,IdCompra,IdProducto,Cantidad,Total")] DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.DETALLE_COMPRA.Add(dETALLE_COMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCompra = new SelectList(db.COMPRAs, "IdCompra", "Contacto", dETALLE_COMPRA.IdCompra);
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLE_COMPRA.IdProducto);
            return View(dETALLE_COMPRA);
        }

        // GET: DETALLE_COMPRA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCompra = new SelectList(db.COMPRAs, "IdCompra", "Contacto", dETALLE_COMPRA.IdCompra);
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLE_COMPRA.IdProducto);
            return View(dETALLE_COMPRA);
        }

        // POST: DETALLE_COMPRA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetalleCompra,IdCompra,IdProducto,Cantidad,Total")] DETALLE_COMPRA dETALLE_COMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dETALLE_COMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCompra = new SelectList(db.COMPRAs, "IdCompra", "Contacto", dETALLE_COMPRA.IdCompra);
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", dETALLE_COMPRA.IdProducto);
            return View(dETALLE_COMPRA);
        }

        // GET: DETALLE_COMPRA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            if (dETALLE_COMPRA == null)
            {
                return HttpNotFound();
            }
            return View(dETALLE_COMPRA);
        }

        // POST: DETALLE_COMPRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DETALLE_COMPRA dETALLE_COMPRA = db.DETALLE_COMPRA.Find(id);
            db.DETALLE_COMPRA.Remove(dETALLE_COMPRA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
