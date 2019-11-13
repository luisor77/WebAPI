using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PrestamoController : ApiController
    {

        public PrestamoController()
        {
        }

        public IHttpActionResult GetAll()
        {
            IList<PrestamoView> registros = null;

            using (var db = new BIBLIOTECAEntities())
            {
                registros = db.View_Prestamo
                           .Select(s => new PrestamoView()
                           {   IdPrestamo = s.IdPrestamo,
                               IdLector = s.IdLector,
                               Nombre = s.Nombre,
                               CI = s.CI,
                               Direccion = s.Direccion,
                               Carrera = s.Carrera,
                               Edad = s.Edad,
                               IdLibro = s.IdLibro,
                               Titulo = s.Titulo,
                               Editorial = s.Editorial,
                               Area = s.Area,
                               FechaPrestamo = s.FechaPrestamo,
                               FechaDevolucion = s.FechaDevolucion,
                               Devuelto = s.Devuelto
                           }).ToList<PrestamoView>();
            }


            if (registros.Count == 0)
            {
                return NotFound();
            }

            return Ok(registros);
        }

        public IHttpActionResult GetOne(int id)
        {
            PrestamoView data = null;

            using (var ctx = new BIBLIOTECAEntities())
            {
                data = ctx.View_Prestamo
                    .Where(s => s.IdLector == id)
                    .Select(s => new PrestamoView()
                    {
                        IdLector = s.IdLector,
                        Nombre = s.Nombre,
                        CI = s.CI,
                        Direccion = s.Direccion,
                        Carrera = s.Carrera,
                        Edad = s.Edad,
                        IdLibro = s.IdLibro,
                        Titulo = s.Titulo,
                        Editorial = s.Editorial,
                        Area = s.Area,
                        FechaPrestamo = s.FechaPrestamo,
                        FechaDevolucion = s.FechaDevolucion,
                        Devuelto = s.Devuelto
                    }).FirstOrDefault<PrestamoView>();
            }

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        public IHttpActionResult PostNew(Prestamo data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Incorrectos.");

            using (var ctx = new BIBLIOTECAEntities())
            {
                ctx.Prestamo.Add(new Prestamo()
                {
                    IdLector = data.IdLector,
                    IdLibro = data.IdLibro,
                    FechaPrestamo = DateTime.Now,
                    FechaDevolucion = data.FechaDevolucion,
                    Devuelto = "N"
        
    });

                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(Prestamo data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Incorrectos");

            using (var ctx = new BIBLIOTECAEntities())
            {
                var exisdata = ctx.Prestamo.Where(s => s.IdPrestamo == data.IdPrestamo)
                                                        .FirstOrDefault<Prestamo>();

                if (exisdata != null)
                {
                    exisdata.FechaDevolucion = DateTime.Now;
                    exisdata.Devuelto = "S";
                  


                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Datos no validos");

            using (var ctx = new BIBLIOTECAEntities())
            {
                var student = ctx.Prestamo
                    .Where(s => s.IdPrestamo == id)
                    .FirstOrDefault();

                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}
