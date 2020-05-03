using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Modelos;
using Repositorio;

namespace Logica
{
    public class UsuarioLogica
    {
        public List<Usuario> obtenerUsuarios()
        {
            var repositorio = new UserRepositorio();
            return repositorio.obtenerUsuarios();
        }

        public List<SelectListItem> obtenerRoles()
        {
            var repositorio = new UserRepositorio();
            return repositorio.obtenerRoles();
        }

        public bool crearUsuario(Usuario usuario)
        {
            var repositorio = new UserRepositorio();
            return repositorio.crearUsuario(usuario);
        }

        public Usuario getUsuarioById(String id)
        {
            var repositorio = new UserRepositorio();
            return repositorio.getUsuarioById(id);
        }

        public void updateUsuario(Usuario usuario)
        {
            var repositorio = new UserRepositorio();
            repositorio.updateUsuario(usuario);
        }

        public void deleteUsuario(String id)
        {
            var repositorio = new UserRepositorio();
            repositorio.deleteUsuario(id);
        }
    }
}
