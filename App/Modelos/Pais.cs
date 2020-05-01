using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Pais
    {
        public int Id { get; set; }

        [Display (Name = "Nombre del país")]
        public string NombrePais { get; set; }

        [Display (Name = "Lista de departamentos")]
        public List<Departamento> Departamentos { get; set; }
    }
}
