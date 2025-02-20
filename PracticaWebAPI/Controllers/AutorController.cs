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
    public class AutorController : ControllerBase
    {
        private readonly bibliotecaContext _context;

        public AutorController(bibliotecaContext context)
        {
            _context = context;
        }

        // Obtener todos los autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        // Obtener un autor por ID, incluyendo sus libros
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _context.Autores.Include(a => a.Libros).FirstOrDefaultAsync(a => a.Id == id);

            if (autor == null)
                return NotFound();

            return autor;
        }

        // Crear un nuevo autor
        [HttpPost]
        public async Task<ActionResult<Libro>> CreateLibro(Libro libro)
        {
            // Verificar si el Autor existe antes de crear el libro
            var autorExistente = await _context.Autores.FindAsync(libro.AutorId);
            if (autorExistente == null)
            {
                return BadRequest("El autor no existe.");
            }

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
        }


        // Actualizar un autor
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAutor(int id, Autor autor)
        {
            if (id != autor.Id)
                return BadRequest();

            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // Eliminar un autor
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
                return NotFound();

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
