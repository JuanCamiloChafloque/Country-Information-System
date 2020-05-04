using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Repositorio
{
    public class UserRepositorio
    {
        public List<Usuario> obtenerUsuarios()
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var list = contexto.AspNetUsers.Select(u => new Usuario
                {
                    Id = u.Id,
                    Email = u.Email,
                    UserName = u.UserName,
                    Rol = u.AspNetRoles.Select(r => new Rol
                    {
                        Id = r.Id,
                        Nombre = r.Name
                    }).FirstOrDefault()
                }).ToList();

                return list;
            }
        }

        public List<Rol> obtenerRoles()
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var list = contexto.AspNetRoles.Select(r => new Rol
                {
                    Id = r.Id,
                    Nombre = r.Name
                }).ToList();

                return list;
            }
        }

        public Usuario getUsuarioById(String id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var usuario = contexto.AspNetUsers.Select(u => new Usuario
                {
                    Id = u.Id,
                    Email = u.Email,
                    UserName = u.UserName,
                    Rol = u.AspNetRoles.Select(r => new Rol
                    {
                        Id = r.Id,
                        Nombre = r.Name
                    }).FirstOrDefault()
                }).FirstOrDefault(u => u.Id == id);

                return usuario;
            }
        }

        public void updateUsuario(Usuario usuario)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var usuarioEncontrado = contexto.AspNetUsers.Find(usuario.Id);
                if (usuarioEncontrado == null)
                {
                    return;
                }
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.UserName = usuario.Email;
                contexto.SaveChanges();
            }
        }

        public void deleteUsuario(String id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var usuarioEncontrado = contexto.AspNetUsers.Find(id);
                if (usuarioEncontrado == null)
                {
                    return;
                }
                contexto.AspNetUsers.Remove(usuarioEncontrado);
                contexto.SaveChanges();
            }
        }
    }
}
