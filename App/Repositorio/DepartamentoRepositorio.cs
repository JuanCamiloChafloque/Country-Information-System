using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class DepartamentoRepositorio
    {
        public List<Departamento> obtenerDepartamentos()
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var list = contexto.Departamentos.Select(d => new Departamento
                {
                    NombreDepartamento = d.NombreDepartamento,
                    Id = d.Id,
                    Pais = new Pais
                    {
                        Id = d.Paises.Id,
                        NombrePais = d.Paises.NombrePais
                    },
                    Ciudades = d.Ciudades.Select(c => new Ciudad
                    {
                        Id = c.Id,
                        NombreCiudad = c.NombreCiudad
                    }).ToList()
                }).ToList();

                return list;
            }
        }

        public bool crearDepartamento(Departamento dep)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var entity = new Departamentos
                {
                    Id = dep.Id,
                    NombreDepartamento = dep.NombreDepartamento,
                    PaisId = dep.Pais.Id
                };
                contexto.Departamentos.Add(entity);
                return Convert.ToBoolean(contexto.SaveChanges());
            }
        }

        public Departamento getDepartamentoById(int id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var dep = contexto.Departamentos.Select(d => new Departamento
                {
                    Id = d.Id,
                    NombreDepartamento = d.NombreDepartamento,
                    Pais = new Pais
                    {
                        Id = d.Paises.Id,
                        NombrePais = d.Paises.NombrePais
                    },
                    Ciudades = d.Ciudades.Select(c => new Ciudad
                    {
                        Id = c.Id,
                        NombreCiudad = c.NombreCiudad
                    }).ToList()
                }).FirstOrDefault(p => p.Id == id);

                return dep;
            }
        }

        public void updateDepartamento(Departamento dep)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var depEncontrado = contexto.Departamentos.Find(dep.Id);
                if (depEncontrado == null)
                {
                    return;
                }
                depEncontrado.NombreDepartamento = dep.NombreDepartamento;
                contexto.SaveChanges();
            }
        }

        public void deleteDepartamento(int id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var depEncontrado = contexto.Departamentos.Find(id);
                if (depEncontrado == null)
                {
                    return;
                }
                contexto.Departamentos.Remove(depEncontrado);
                contexto.SaveChanges();
            }
        }
    }
}
