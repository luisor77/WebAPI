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
    
    public partial class View_Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdLector { get; set; }
        public string Nombre { get; set; }
        public string CI { get; set; }
        public string Direccion { get; set; }
        public string Carrera { get; set; }
        public int Edad { get; set; }
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Area { get; set; }
        public System.DateTime FechaPrestamo { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public string Devuelto { get; set; }
    }
}
