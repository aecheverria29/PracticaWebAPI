using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly bibliotecaContext _context;

        public LibroController(bibliotecaContext context)
        {
            _context = context;
        }

        // Obtener todos los libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            return await _context.Libros.Include(l => l.Autor).ToListAsync();
        }

        // Obtener un libro por ID, incluyendo el nombre del autor
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.Include(l => l.Autor).FirstOrDefaultAsync(l => l.Id == id);

            if (libro == null)
                return NotFound();

            return libro;
        }

        // Crear un nuevo libro
        [HttpPost]
        public async Task<ActionResult<Libro>> CreateLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
        }

        // Actualizar un libro
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibro(int id, Libro libro)
        {
            if (id != libro.Id)
                return BadRequest();

            _context.Entry(libro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar un libro
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
                return NotFound();

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
