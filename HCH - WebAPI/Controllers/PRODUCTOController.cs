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
    public class PRODUCTOController : Controller
    {
        private Modelo_HCH db = new Modelo_HCH();

        // GET: PRODUCTO
        public ActionResult Index()
        {
            var pRODUCTOes = db.PRODUCTOes.Include(p => p.CATEGORIA).Include(p => p.MARCA);
            return View(pRODUCTOes.ToList());
        }

        // GET: PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion");
            ViewBag.IdMarca = new SelectList(db.MARCAs, "IdMarca", "Descripcion");
            return View();
        }

        // POST: PRODUCTO/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen,Activo,FechaRegistro")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOes.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion", pRODUCTO.IdCategoria);
            ViewBag.IdMarca = new SelectList(db.MARCAs, "IdMarca", "Descripcion", pRODUCTO.IdMarca);
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion", pRODUCTO.IdCategoria);
            ViewBag.IdMarca = new SelectList(db.MARCAs, "IdMarca", "Descripcion", pRODUCTO.IdMarca);
            return View(pRODUCTO);
        }

        // POST: PRODUCTO/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Nombre,Descripcion,IdMarca,IdCategoria,Precio,Stock,RutaImagen,Activo,FechaRegistro")] PRODUCTO pRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIAs, "IdCategoria", "Descripcion", pRODUCTO.IdCategoria);
            ViewBag.IdMarca = new SelectList(db.MARCAs, "IdMarca", "Descripcion", pRODUCTO.IdMarca);
            return View(pRODUCTO);
        }

        // GET: PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTOes.Find(id);
            db.PRODUCTOes.Remove(pRODUCTO);
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
