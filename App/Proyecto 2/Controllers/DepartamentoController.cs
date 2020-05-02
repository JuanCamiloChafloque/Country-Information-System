using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelos;
using Logica;
using Proyecto_2.Data;

namespace Proyecto_2.Controllers
{
    [Authorize(Roles = "Usuario")]
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            var logic = new DepartamentoLogica();
            var listDep = logic.obtenerDepartamentos();
            return View(listDep);
        }

        // GET: Departamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new DepartamentoLogica();
            Departamento departamento = logic.getDepartamentoById(id ?? 0);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamento/Create/5
        public ActionResult Create(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreDepartamento")] Departamento departamento, String idPais)
        {
                       
            if (ModelState.IsValid)
            {
                var logicPais = new PaisLogica();
                var logic = new DepartamentoLogica();
                departamento.Pais = logicPais.getPaisById(Int32.Parse(idPais));
                logic.crearDepartamento(departamento);
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Departamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new DepartamentoLogica();
            Departamento departamento = logic.getDepartamentoById(id ?? 0);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreDepartamento")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                var logic = new DepartamentoLogica();
                logic.updateDepartamento(departamento);
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        // GET: Departamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new DepartamentoLogica();
            Departamento departamento = logic.getDepartamentoById(id ?? 0);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var logic = new DepartamentoLogica();
            logic.deleteDepartamento(id);
            return RedirectToAction("Index");
        }
    }
}
