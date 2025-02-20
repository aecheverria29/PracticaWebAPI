using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaWebAPI.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titulo { get; set; }

        [Required]
        public int AñoPublicacion { get; set; }

        // Clave foránea a Autor
        [Required]
        public int AutorId { get; set; }

        // ⚠️ Hacer esto nullable evita errores en la API
        public Autor? Autor { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [MaxLength(500)]
        public string Resumen { get; set; }
    }
}
