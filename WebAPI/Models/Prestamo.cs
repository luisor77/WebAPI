//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamo
    {
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
        public System.DateTime FechaPrestamo { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public string Devuelto { get; set; }
        public int IdPrestamo { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual Libro Libro { get; set; }
    }
}