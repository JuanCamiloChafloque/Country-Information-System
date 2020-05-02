using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class CiudadRepositorio
    {
        public List<Ciudad> obtenerCiudades()
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var list = contexto.Ciudades.Select(c => new Ciudad
                {
                    NombreCiudad = c.NombreCiudad,
                    Id = c.Id,
                    Departamento = new Departamento
                    {
                        Id = c.Departamentos.Id,
                        NombreDepartamento = c.Departamentos.NombreDepartamento,
                        Pais = new Pais
                        {
                            Id = c.Departamentos.Paises.Id,
                            NombrePais = c.Departamentos.Paises.NombrePais
                        }
                    }
                }).ToList();

                return list;
            }
        }

        public bool crearCiudad(Ciudad ciudad)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var entity = new Ciudades
                {
                    Id = ciudad.Id,
                    NombreCiudad = ciudad.NombreCiudad,
                    DepartamentoId = ciudad.Departamento.Id
                };

                contexto.Ciudades.Add(entity);
                return Convert.ToBoolean(contexto.SaveChanges());
            }
        }

        public Ciudad getCiudadById(int id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var ciu = contexto.Ciudades.Select(c => new Ciudad
                {
                    Id = c.Id,
                    NombreCiudad = c.NombreCiudad,
                    Departamento = new Departamento
                    {
                        Id = c.Departamentos.Id,
                        NombreDepartamento = c.Departamentos.NombreDepartamento,
                        Pais = new Pais
                        {
                            Id = c.Departamentos.Paises.Id,
                            NombrePais = c.Departamentos.Paises.NombrePais
                        }
                    }
                    
                }).FirstOrDefault(p => p.Id == id);

                return ciu;
            }
        }

        public void updateCiudad(Ciudad ciudad)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var ciuEncontrado = contexto.Ciudades.Find(ciudad.Id);
                if (ciuEncontrado == null)
                {
                    return;
                }
                ciuEncontrado.NombreCiudad = ciudad.NombreCiudad;
                contexto.SaveChanges();
            }
        }

        public void deleteCiudad(int id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var ciuEncontrado = contexto.Ciudades.Find(id);
                if (ciuEncontrado == null)
                {
                    return;
                }
                contexto.Ciudades.Remove(ciuEncontrado);
                contexto.SaveChanges();
            }
        }
    }
}
