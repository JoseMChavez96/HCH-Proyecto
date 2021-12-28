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
    public class COMPRAController : Controller
    {
        private Modelo_HCH db = new Modelo_HCH();

        // GET: COMPRA
        public ActionResult Index()
        {
            var cOMPRAs = db.COMPRAs.Include(c => c.USUARIO);
            return View(cOMPRAs.ToList());
        }

        // GET: COMPRA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRAs.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // GET: COMPRA/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres");
            return View();
        }

        // POST: COMPRA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompra,IdUsuario,TotalProducto,Total,Contacto,Telefono,Direccion,IdDistrito,FechaCompra")] COMPRA cOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.COMPRAs.Add(cOMPRA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres", cOMPRA.IdUsuario);
            return View(cOMPRA);
        }

        // GET: COMPRA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRAs.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres", cOMPRA.IdUsuario);
            return View(cOMPRA);
        }

        // POST: COMPRA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompra,IdUsuario,TotalProducto,Total,Contacto,Telefono,Direccion,IdDistrito,FechaCompra")] COMPRA cOMPRA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPRA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "Nombres", cOMPRA.IdUsuario);
            return View(cOMPRA);
        }

        // GET: COMPRA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRA cOMPRA = db.COMPRAs.Find(id);
            if (cOMPRA == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRA);
        }

        // POST: COMPRA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPRA cOMPRA = db.COMPRAs.Find(id);
            db.COMPRAs.Remove(cOMPRA);
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
