using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Repositorio;

namespace Logica
{
    public class PaisLogica
    {
        public List<Pais> obtenerPaises()
        {
            var repositorio = new PaisRepositorio();
            return repositorio.obtenerPaises();
        }

        public bool crearPais(Pais pais)
        {
            var repositorio = new PaisRepositorio();
            return repositorio.crearPais(pais);
        }

        public Pais getPaisById(int id)
        {
            var repositorio = new PaisRepositorio();
            return repositorio.getPaisById(id);
        }

        public void updatePais(Pais pais)
        {
            var repositorio = new PaisRepositorio();
            repositorio.updatePais(pais);
        }

        public void deletePais(int id)
        {
            var repositorio = new PaisRepositorio();
            repositorio.deletePais(id);
        }
    }
}
