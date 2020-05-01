using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Ciudad
    {

        public int Id { get; set; }

        [Display (Name = "Nombre de la ciudad")]
        public string NombreCiudad { get; set; }

        [Display (Name = "Nombre del departamento")]
        public Departamento Departamento { get; set; }

    }
}
