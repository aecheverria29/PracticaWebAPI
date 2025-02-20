using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaWebAPI.Models;

namespace PracticaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly bibliotecaContext _bibliotecaContext;
        public AutorController(bibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }
        [HttpGet]
        [Route("MostrarAutor")]
        public IActionResult GetAutor()
        {
            List<Autor> listadoAutor = (from e in _bibliotecaContext.Autor select e).ToList();

            if (listadoAutor.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoAutor);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            var autor = (from e in _bibliotecaContext.Autor
                            join t in _bibliotecaContext.Libro
                            on e.id_autor equals t.id_autor
                            where e.id_autor == id
                            select new
                            {
                                e.id_autor,
                                e.nombre,
                                e.nacionalidad,
                                t.titulo
                            }).ToList();

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }
        [HttpPost]
        [Route("CrearAutor")]
        public IActionResult GuardarBiblioteca([FromBody] Autor autor)
        {
            try
            {
                _bibliotecaContext.Autor.Add(autor);
                _bibliotecaContext.SaveChanges();
                return Ok(autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("modificar/{id}")]
        public IActionResult actualizarAutor(int id, [FromBody] Autor autorActualizar)
        {
            Autor? autorActual = (from e in _bibliotecaContext.Autor where e.id_autor == id select e).FirstOrDefault();

            if (autorActual == null)
            {
                return NotFound();
            }

            autorActual.nombre = autorActualizar.nombre;
            autorActual.nacionalidad = autorActualizar.nacionalidad;

            _bibliotecaContext.Entry(autorActual).State = EntityState.Modified;
            _bibliotecaContext.SaveChanges();

            return Ok(autorActual);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult eliminarAutor(int id)
        {
            Autor? autor = (from e in _bibliotecaContext.Autor where e.id_autor == id select e).FirstOrDefault();

            if (autor == null)
            {
                return NotFound();
            }

            _bibliotecaContext.Autor.Attach(autor);
            _bibliotecaContext.Autor.Remove(autor);
            _bibliotecaContext.SaveChanges(true);
            return Ok(autor);
        }
    }

}
