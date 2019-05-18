﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass.Data.Dto.EstadoCompra
{
    public class Get
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
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