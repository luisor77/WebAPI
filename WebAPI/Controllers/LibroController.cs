using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LibroController : ApiController
    {
        public LibroController()
        {
        }

        public IHttpActionResult GetAll()
        {
            IList<LibroView> registros = null;


            using (var db = new BIBLIOTECAEntities())
            {
                registros = db.Libro
                           .Select(s => new LibroView()
                           {
                               IdLibro = s.IdLibro,
                               Titulo = s.Titulo,
                               Editorial = s.Editorial,
                               Area = s.Area
                           }).ToList<LibroView>();
            }



            if (registros.Count == 0)
            {
                return NotFound();
            }

            return Ok(registros);
        }

        public IHttpActionResult GetOne(int id)
        {
            LibroView data = null;

            using (var ctx = new BIBLIOTECAEntities())
            {
                data = ctx.Libro
                    .Where(s => s.IdLibro == id)
                    .Select(s => new LibroView()
                    {
                        IdLibro = s.IdLibro,
                        Titulo = s.Titulo,
                        Editorial = s.Editorial,
                        Area = s.Area
                    }).FirstOrDefault<LibroView>();
            }

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        public IHttpActionResult PostNew(Libro data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Incorrectos.");

            using (var ctx = new BIBLIOTECAEntities())
            {
                ctx.Libro.Add(new Libro()
                {
                    IdLibro = data.IdLibro,
                    Titulo = data.Titulo,
                    Editorial = data.Editorial,
                    Area = data.Area


                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult Put(Libro data)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos Incorrectos");

            using (var ctx = new BIBLIOTECAEntities())
            {
                var exisdata = ctx.Libro.Where(s => s.IdLibro == data.IdLibro)
                                                        .FirstOrDefault<Libro>();

                if (exisdata != null)
                {


                    exisdata.Titulo = data.Titulo;
                    exisdata.Editorial = data.Editorial;
                    exisdata.Area = data.Area;

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
                var student = ctx.Libro
                    .Where(s => s.IdLibro == id)
                    .FirstOrDefault();

                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }


    }
}
