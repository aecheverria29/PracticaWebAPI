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
    }

}
