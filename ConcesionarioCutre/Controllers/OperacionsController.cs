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
    public class OperacionsController : Controller
    {
        private ConcesionarioEntities db = new ConcesionarioEntities();

        // GET: Operacions
        public ActionResult Index()
        {
            var operacions = db.Operacions.Include(o => o.Coch).Include(o => o.Cliente).Include(o => o.Empleado);
            return View(operacions.ToList());
        }

        // GET: Operacions/Details/5
        public ActionResult Details(int? id,int? id1, int? id2)
        {
            if (id == null||id1==null||id2==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacions.Where(o=>o.IDCOCHE==id||o.IDCLIENTE==id2||o.IDEMPLEADO==id1).First();
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // GET: Operacions/Create
        public ActionResult Create()
        {

            ViewBag.IDCOCHE = new SelectList(db.Coches, "ID", "REFERENCIA");
            ViewBag.IDCLIENTE = new SelectList(db.Clientes, "ID", "NIF");
            ViewBag.IDEMPLEADO = new SelectList(db.Empleados, "ID", "NIF");
            

            ViewBag.TIPO = db.Operacions.Select(c => new SelectListItem
            {
                Value = c.TIPO.ToString(),
                Text = c.TIPO.ToString()
            }).Distinct();



            return View();
        }

        // POST: Operacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCOCHE,IDEMPLEADO,IDCLIENTE,PRECIO,TIPO")]Operacion operacion)
        {

            if (ModelState.IsValid)
            {
                db.Operacions.Add(operacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCOCHE = new SelectList(db.Coches, "ID", "REFERENCIA", operacion.IDCOCHE);
            ViewBag.IDCLIENTE = new SelectList(db.Clientes, "ID", "NIF", operacion.IDCLIENTE);
            ViewBag.IDEMPLEADO = new SelectList(db.Empleados, "ID", "NIF", operacion.IDEMPLEADO);
            return View(operacion);
        }

        // GET: Operacions/Edit/5
        public ActionResult Edit(int? id,int? id1,int? id2)
        {

            if (id == null|| id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Operacion operacion = db.Operacions.Where(o => o.IDCOCHE == id || o.IDCLIENTE == id2 || o.IDEMPLEADO == id1).First();
            if (operacion == null)
            {
                return HttpNotFound();
            }

            ViewBag.IDCOCHE = new SelectList(db.Coches, "ID", "REFERENCIA", operacion.IDCOCHE);
            ViewBag.IDCLIENTE = new SelectList(db.Clientes, "ID", "NIF", operacion.IDCLIENTE);
            ViewBag.IDEMPLEADO = new SelectList(db.Empleados, "ID", "NIF", operacion.IDEMPLEADO);

            ViewBag.TIPO = db.Operacions.Select(c => new SelectListItem
            {
                Value = c.TIPO.ToString(),
                Text = c.TIPO.ToString()
            }).Distinct();

            return View(operacion);
        }

        // POST: Operacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCOCHE,IDEMPLEADO,IDCLIENTE,PRECIO,TIPO")] Operacion operacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCOCHE = new SelectList(db.Coches, "ID", "REFERENCIA", operacion.IDCOCHE);
            ViewBag.IDCLIENTE = new SelectList(db.Clientes, "ID", "NIF", operacion.IDCLIENTE);
            ViewBag.IDEMPLEADO = new SelectList(db.Empleados, "ID", "NIF", operacion.IDEMPLEADO);
            return View(operacion);
        }

        // GET: Operacions/Delete/5
        public ActionResult Delete(int? id, int? id1, int? id2)
        {
            if (id == null || id1 == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operacion operacion = db.Operacions.Where(o => o.IDCOCHE == id || o.IDCLIENTE == id2 || o.IDEMPLEADO == id1).First();
            if (operacion == null)
            {
                return HttpNotFound();
            }
            return View(operacion);
        }

        // POST: Operacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int? id1, int? id2)
        {
            Operacion operacion = db.Operacions.Where(o => o.IDCOCHE == id || o.IDCLIENTE == id2 || o.IDEMPLEADO == id1).First();
            db.Operacions.Remove(operacion);
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
