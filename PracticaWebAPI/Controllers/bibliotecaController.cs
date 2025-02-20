using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaWebAPI.Models;

namespace PracticaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly bibliotecaContext _bibliotecaContext;

        public BibliotecaController(bibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        [HttpGet] // ← Añadir este método para que Swagger lo detecte
        public IActionResult Get()
        {
            return Ok("Biblioteca API funcionando correctamente.");
        }
    }
}