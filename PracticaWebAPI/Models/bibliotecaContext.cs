using Microsoft.EntityFrameworkCore;

namespace PracticaWebAPI.Models
{
    public class bibliotecaContext : DbContext
    {
        public bibliotecaContext(DbContextOptions<bibliotecaContext> options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
