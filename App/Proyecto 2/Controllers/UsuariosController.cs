using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using System.Security.Claims;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Logica;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Modelos;
using Proyecto_2.Data;
using Proyecto_2.Models;

namespace Proyecto_2.Controllers
{
    [Authorize (Roles ="Administrador")]
    public class UsuariosController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public UsuariosController()
        {

        }

        public UsuariosController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

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
            ViewBag.CRoles = logic.obtenerRoles();
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Email,Password")] Usuario usuario, String[] CRoles)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = usuario.Email, Email = usuario.Email };
                var result = await UserManager.CreateAsync(user, usuario.Password);
                if (result.Succeeded)
                {
                    var currentUser = UserManager.FindByName(user.UserName);
                    if(CRoles != null)
                    {
                        foreach(var r in CRoles)
                        {
                            var roleResult = UserManager.AddToRole(currentUser.Id, r);
                        }
                    }
                    return RedirectToAction("Index");
                }
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
            ViewBag.CRoles = logic.obtenerRoles();
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,UserName")] Usuario usuario, String[] CRoles)
        {
            if (ModelState.IsValid)
            {
                var logic = new UsuarioLogica();
                logic.updateUsuario(usuario);
                var currentUser = UserManager.FindByName(usuario.Email);
                UserManager.RemoveFromRole(currentUser.Id, "Administrador");
                UserManager.RemoveFromRole(currentUser.Id, "Usuario");
                if (CRoles != null)
                {
                    foreach (var r in CRoles)
                    {
                        var roleResult = UserManager.AddToRole(currentUser.Id, r);
                    }
                }
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
