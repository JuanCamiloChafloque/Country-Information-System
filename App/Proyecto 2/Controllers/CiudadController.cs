using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logica;
using Modelos;
using Proyecto_2.Data;

namespace Proyecto_2.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class CiudadController : Controller
    {
        // GET: Ciudad
        public ActionResult Index()
        {
            var logic = new CiudadLogica();
            var listCiudades = logic.obtenerCiudades();
            return View(listCiudades);
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new CiudadLogica();
            Ciudad ciudad = logic.getCiudadById(id ?? 0);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreCiudad")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                var logic = new CiudadLogica();
                logic.crearCiudad(ciudad);
                return RedirectToAction("Index");
            }

            return View(ciudad);
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new CiudadLogica();
            Ciudad ciudad = logic.getCiudadById(id ?? 0);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreCiudad")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                var logic = new CiudadLogica();
                logic.updateCiudad(ciudad);
                return RedirectToAction("Index");
            }
            return View(ciudad);
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new CiudadLogica();
            Ciudad ciudad = logic.getCiudadById(id ?? 0);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var logic = new CiudadLogica();
            logic.deleteCiudad(id);
            return RedirectToAction("Index");
        }
    }
}
