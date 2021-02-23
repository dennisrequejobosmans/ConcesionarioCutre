using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConcesionarioCutre;

namespace ConcesionarioCutre.Controllers
{
    public class CochesController : Controller
    {
        private ConcesionarioEntities db = new ConcesionarioEntities();

        // GET: Coches
        public ActionResult Index()
        {
            return View(db.Coches.ToList());
        }

        // GET: Coches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coch coch = db.Coches.Find(id);
            if (coch == null)
            {
                return HttpNotFound();
            }
            return View(coch);
        }

        // GET: Coches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coches/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MARCA,MODELO,NUM_PUERTAS,COLOR,KILOMETROS,TIPO,GARANTIA,FOTOGRAFIA")] Coch coch)
        {
            if (ModelState.IsValid)
            {
                db.Coches.Add(coch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coch);
        }

        // GET: Coches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coch coch = db.Coches.Find(id);
            if (coch == null)
            {
                return HttpNotFound();
            }
            return View(coch);
        }

        // POST: Coches/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MARCA,MODELO,NUM_PUERTAS,COLOR,KILOMETROS,TIPO,GARANTIA,FOTOGRAFIA")] Coch coch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coch);
        }

        // GET: Coches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coch coch = db.Coches.Find(id);
            if (coch == null)
            {
                return HttpNotFound();
            }
            return View(coch);
        }

        // POST: Coches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coch coch = db.Coches.Find(id);
            db.Coches.Remove(coch);
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
