using System;
using System.Collections.Generic;

namespace Glass.Data.Dto.Compra 
{
    public class Get
    {
        public Int32 Id
        {get; set;}
        public Int32 Estado
        {get; set;}
        public Reserva Reserva
        {get; set;}
    }
    
    public class Patch
    {
        public Int32 Id
        {get; set;}
        public Int32 Estado
        {get; set;}
        public Int32 Reserva
        {get; set;}
        public DateTime Modificacion
        {get; set;}
    }
    
    public class Delete
    {
        public Int32 Id
        {get; set;}
        public Int32 Reserva
        {get; set;}
        public DateTime Fecha
        {get; set;}
    }
    
    public class Reserva
    {
        public Int32 Id
        {get; set;}
        public Int32 Usuario
        {get; set;}
        public List<Dto.Reserva.ReservaStock> Reservas
        {get; set;}
    }
}