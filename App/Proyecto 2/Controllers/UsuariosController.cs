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
    [Authorize (Roles ="Administrador")]
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            var logic = new UsuarioLogica();
            var listUsuarios = logic.obtenerUsuarios();
            return View(listUsuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new UsuarioLogica();
            Usuario usuario = logic.getUsuarioById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var logic = new UsuarioLogica();
            ViewBag.ComboRoles = logic.obtenerRoles();
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,UserName")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var logic = new UsuarioLogica();
                logic.crearUsuario(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new UsuarioLogica();
            Usuario usuario = logic.getUsuarioById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,UserName")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var logic = new UsuarioLogica();
                logic.updateUsuario(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var logic = new UsuarioLogica();
            Usuario usuario = logic.getUsuarioById(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var logic = new UsuarioLogica();
            logic.deleteUsuario(id);
            return RedirectToAction("Index");
        }
    }
}
