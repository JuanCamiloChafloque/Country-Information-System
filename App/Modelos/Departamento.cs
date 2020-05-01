using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Departamento
    {
        public int Id { get; set; }

        [Display (Name ="Nombre del departamento")]
        public string NombreDepartamento { get; set; }

        [Display (Name = "Nombre del país")]
        public Pais Pais { get; set; }
        public List<Ciudad> Ciudades { get; set; }
    }
}
