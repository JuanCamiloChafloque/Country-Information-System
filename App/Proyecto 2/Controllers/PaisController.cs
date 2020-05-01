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
    [Authorize (Roles = "Usuario")]
    public class PaisController : Controller
    {
        // GET: Pais
        public ActionResult Index()
        {
            var logic = new PaisLogica();
            var listPaises = logic.obtenerPaises();
            return View(listPaises);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new PaisLogica();
            Pais pais = logic.getPaisById(id ?? 0);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombrePais")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                var logic = new PaisLogica();
                logic.crearPais(pais);
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new PaisLogica();
            Pais pais = logic.getPaisById(id ?? 0);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombrePais")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                var logic = new PaisLogica();
                logic.updatePais(pais);
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new PaisLogica();
            Pais pais = logic.getPaisById(id ?? 0);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var logic = new PaisLogica();
            logic.deletePais(id);
            return RedirectToAction("Index");
        }
    }
}
