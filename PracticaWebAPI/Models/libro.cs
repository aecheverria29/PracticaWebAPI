using System.ComponentModel.DataAnnotations;

namespace PracticaWebAPI.Models
{
    public class libro
    {
        [Key]
        public int id { get; set; }
        public string titulo { get; set; }
        public int añopublicacion {  get; set; }
        public int id_autor { get; set; }
        public int id_categoria { get; set; }
        public string resumen { get; set; }
    }
}
