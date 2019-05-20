using System;
using System.Collections.Generic;

namespace Glass.Data.Dto.Reserva 
{
    public class Get
    {
        public Int32 Id { get; set;}
        public Int32 Usuario
        {get; set;}
        public Int32 Compra
        {get; set;}
        public List<ReservaStock> Reservas
		{ get; set; }
	}
    
    public class Post
    {
        public Int32 Id { get; set;}
        public Int32 Usuario
        {get; set;}
        public Int32 Compra
        {get; set;}
        public List<ReservaStock> Reservas
        {get; set;}
    }
    
    public class Delete
    {
        public Int32 Id
        {get; set;}
        public DateTime Fecha
        {get; set;}
    }
    
    public class ReservaStock
    {
        public Int32 Cantidad
        {get; set;}
        public Int32 Producto
        {get; set;}
    }
}
