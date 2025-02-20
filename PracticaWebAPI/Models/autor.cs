using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PracticaWebAPI.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nacionalidad { get; set; }

        // Relación con libros (un autor puede tener varios libros)
        public List<Libro> Libros { get; set; } = new List<Libro>();
    }
}
