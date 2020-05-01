using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Repositorio;

namespace Logica
{
    public class DepartamentoLogica
    {
        public List<Departamento> obtenerDepartamentos()
        {
            var repositorio = new DepartamentoRepositorio();
            return repositorio.obtenerDepartamentos();
        }

        public bool crearDepartamento(Departamento dep)
        {
            var repositorio = new DepartamentoRepositorio();
            return repositorio.crearDepartamento(dep);
        }

        public Departamento getDepartamentoById(int id)
        {
            var repositorio = new DepartamentoRepositorio();
            return repositorio.getDepartamentoById(id);
        }

        public void updateDepartamento(Departamento dep)
        {
            var repositorio = new DepartamentoRepositorio();
            repositorio.updateDepartamento(dep);
        }

        public void deleteDepartamento(int id)
        {
            var repositorio = new DepartamentoRepositorio();
            repositorio.deleteDepartamento(id);
        }
    }
}
