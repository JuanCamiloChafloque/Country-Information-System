using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario
    {
        public String Id { get; set; }

        [Display (Name = "Email del usuario")]
        public String Email { get; set; }

        [Display (Name = "Nombre del usuario")]
        public String UserName { get; set; }

        [Display (Name = "Contraseña del usuario")]
        public String Password { get; set; }

        [Display (Name = "Roles del usuario")]
        public List<Rol> Roles { get; set; }
    }
}
