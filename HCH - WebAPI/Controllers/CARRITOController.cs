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
    public class CARRITOController : Controller
    {
        private Modelo_HCH db = new Modelo_HCH();

        // GET: CARRITO
        public ActionResult Index()
        {
            var cARRITOes = db.CARRITOes.Include(c => c.PRODUCTO).Include(c => c.USUARIO);
            return View(cARRITOes.ToList());
        }

        // GET: CARRITO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITO cARRITO = db.CARRITOes.Find(id);
            if (cARRITO == null)
            {
                return HttpNotFound();
            }
            return View(cARRITO);
        }

        // GET: CARRITO/Create
        public ActionResult Create()
        {
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres");
            return View();
        }

        // POST: CARRITO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCarrito,IdUsuario,IdProducto")] CARRITO cARRITO)
        {
            if (ModelState.IsValid)
            {
                db.CARRITOes.Add(cARRITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", cARRITO.IdProducto);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres", cARRITO.IdUsuario);
            return View(cARRITO);
        }

        // GET: CARRITO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITO cARRITO = db.CARRITOes.Find(id);
            if (cARRITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", cARRITO.IdProducto);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres", cARRITO.IdUsuario);
            return View(cARRITO);
        }

        // POST: CARRITO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCarrito,IdUsuario,IdProducto")] CARRITO cARRITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cARRITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProducto = new SelectList(db.PRODUCTOes, "IdProducto", "Nombre", cARRITO.IdProducto);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres", cARRITO.IdUsuario);
            return View(cARRITO);
        }

        // GET: CARRITO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CARRITO cARRITO = db.CARRITOes.Find(id);
            if (cARRITO == null)
            {
                return HttpNotFound();
            }
            return View(cARRITO);
        }

        // POST: CARRITO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CARRITO cARRITO = db.CARRITOes.Find(id);
            db.CARRITOes.Remove(cARRITO);
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
