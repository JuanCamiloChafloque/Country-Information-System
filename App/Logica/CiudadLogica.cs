using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using Repositorio;

namespace Logica
{
    public class CiudadLogica
    {
        public List<Ciudad> obtenerCiudades()
        {
            var repositorio = new CiudadRepositorio();
            return repositorio.obtenerCiudades();
        }

        public bool crearCiudad(Ciudad ciudad)
        {
            var repositorio = new CiudadRepositorio();
            return repositorio.crearCiudad(ciudad);
        }

        public Ciudad getCiudadById(int id)
        {
            var repositorio = new CiudadRepositorio();
            return repositorio.getCiudadById(id);
        }

        public void updateCiudad(Ciudad ciudad)
        {
            var repositorio = new CiudadRepositorio();
            repositorio.updateCiudad(ciudad);
        }

        public void deleteCiudad(int id)
        {
            var repositorio = new CiudadRepositorio();
            repositorio.deleteCiudad(id);
        }
    }
}
