using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Repositorio
{
    public class PaisRepositorio
    {
        public List<Pais> obtenerPaises()
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var list = contexto.Paises.Select(p => new Pais
                {
                    NombrePais = p.NombrePais,
                    Id = p.Id,
                    Departamentos = p.Departamentos.Select(d => new Departamento
                    {
                        Id = d.Id,
                        NombreDepartamento = d.NombreDepartamento
                    }).ToList()
                }).ToList();

                return list;
            }
        }

        public bool crearPais(Pais pais)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var entity = new Paises
                {
                    Id = pais.Id,
                    NombrePais = pais.NombrePais
                };

                contexto.Paises.Add(entity);
                return Convert.ToBoolean(contexto.SaveChanges());
            }
        }

        public Pais getPaisById(int id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var pais = contexto.Paises.Select(p => new Pais
                {
                    Id = p.Id,
                    NombrePais = p.NombrePais,
                    Departamentos = p.Departamentos.Select(d => new Departamento
                    {
                        Id = d.Id,
                        NombreDepartamento = d.NombreDepartamento
                    }).ToList()
                }).FirstOrDefault(p => p.Id == id);

                return pais;
            }
        }

        public void updatePais(Pais pais)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var paisEncontrado = contexto.Paises.Find(pais.Id);
                if(paisEncontrado == null)
                {
                    return;
                }
                paisEncontrado.NombrePais = pais.NombrePais;
                contexto.SaveChanges();
            }
        }

        public void deletePais(int id)
        {
            using (var contexto = new dbProwebNETEntities())
            {
                var paisEncontrado = contexto.Paises.Find(id);
                if(paisEncontrado == null)
                {
                    return;
                }
                contexto.Paises.Remove(paisEncontrado);
                contexto.SaveChanges();
            }
        }
    }
}
