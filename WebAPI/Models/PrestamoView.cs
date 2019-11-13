using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PrestamoView
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