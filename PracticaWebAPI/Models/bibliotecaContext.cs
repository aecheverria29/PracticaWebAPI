using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PracticaWebAPI.Models
{
    public class bibliotecaContext:DbContext   
    {
        public bibliotecaContext(DbContextOptions<bibliotecaContext> options) : base (options) 
        {
        
        }
    }
}
