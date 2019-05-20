using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Data.Dto.Laboratorio
{
    public class Get
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }

		public override String ToString()
		{
			return Nombre;
		}
	}
    public class Post
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public DateTime Creacion { get; set; }
    }
    public class Delete
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
