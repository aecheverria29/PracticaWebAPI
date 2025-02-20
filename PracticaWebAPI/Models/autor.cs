using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PracticaWebAPI.Models
{
    public class Autor
    {
        [Key]
        public int id_autor {  get; set; }
        public string? nombre { get; set; }
        public string? nacionalidad { get; set; }

    
    }
}
