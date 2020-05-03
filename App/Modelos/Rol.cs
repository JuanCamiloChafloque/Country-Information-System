using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Rol
    {
        public String Id { get; set; }

        [Display (Name = "Rol")]
        public String Nombre { get; set; }
    }
}
