using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Data.Dto.Producto
{
    public class Get
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Boolean NecesitaReceta { get; set; }
        public Int32 PrecioUnidad { get; set; }
        public Int32 MaximoSemanal { get; set; }
        public Int32 PesoGramo { get; set; }
        public Int32 Laboratorio { get; set; }
        public Int32 Tipo { get; set; }
        public Int32 Stock { get; set; }

    }
    public class Post
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Creacion { get; set; }
    }
    public class Put
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public DateTime Modificacion { get; set; }
    }
    public class Delete
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
