using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class LibroView
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Area { get; set; }

    }
}