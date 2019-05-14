using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Data.Dto.Usuario
{
    public class Auth
    {
        public String Rut { get; set; }
        public String Token { get; set; }
        public DateTime Creacion { get; set; }
        public Int32 Expiracion { get; set; }
    }

    public class Get
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Int32 Rol { get; set; }
    }

    public class Post
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public DateTime Creacion { get; set; }
        public Int32 Rol { get; set; }
    }

    public class Patch
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime Modificacion { get; set; }
    }

    public class Put
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime Modificacion { get; set; }
        public Int32 Rol { get; set; }
    }

    public class Delete
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public DateTime Fecha { get; set; }
    }
}
