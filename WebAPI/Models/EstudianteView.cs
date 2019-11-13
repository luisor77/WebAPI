using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EstudianteView
    {
        public int IdLector { get; set; }
        public string CI { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Carrera { get; set; }
        public int Edad { get; set; }
    }
}