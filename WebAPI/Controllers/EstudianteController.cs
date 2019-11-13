using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EstudianteController : ApiController
    {

        public EstudianteController()
        {
        }

        public IHttpActionResult GetAll()
        {
            IList<EstudianteView> registros = null;

           
                using (var db = new BIBLIOTECAEntities())
                {
                    registros = db.Estudiante
                               .Select(s => new EstudianteView()
                               {
                                   IdLector = s.IdLector,
                                   Nombre = s.Nombre,
                                   CI = s.CI,
                                   Direccion = s.Direccion,
                                   Carrera = s.Carrera,
                                   Edad = s.Edad
                               }).ToList<EstudianteView>();
                }
                    


            if (registros.Count == 0)
            {
                return NotFound();
            }

            return Ok(registros);
        }

        public IHttpActionResult GetOne(int id)
        {
            EstudianteView data = null;

            using (var ctx = new BIBLIOTECAEntities())
            {
                data = ctx.Estudiante
                    .Where(s => s.IdLector == id)
                    .Select(s => new EstudianteView()
                    {
                        IdLector = s.IdLector,
                        Nombre = s.Nombre,
                        CI = s.CI,
                        Direccion = s.Direccion,
                        Carrera = s.Carrera,
                        Edad = s.Edad
                    }).FirstOrDefault<EstudianteView>();
            }

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        public IHttpActionResult PostNew(Estudiante data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Incorrectos.");

            using (var ctx = new BIBLIOTECAEntities())
            {
                ctx.Estudiante.Add(new Estudiante()
                {
                    IdLector = data.IdLector,
                    CI = data.CI,
                    Nombre = data.Nombre,
                    Direccion = data.Direccion,
                    Carrera = data.Carrera,
                    Edad = data.Edad

        
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(Estudiante data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Incorrectos");

            using (var ctx = new BIBLIOTECAEntities())
            {
                var exisdata = ctx.Estudiante.Where(s => s.IdLector== data.IdLector)
                                                        .FirstOrDefault<Estudiante>();

                if (exisdata != null)
                {

                    exisdata.CI = data.CI;
                    exisdata.Nombre = data.Nombre;
                    exisdata.Direccion = data.Direccion;
                    exisdata.Carrera = data.Carrera;
                    exisdata.Edad = data.Edad;


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
                var student = ctx.Estudiante
                    .Where(s => s.IdLector == id)
                    .FirstOrDefault();

                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}
