using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bibliotecaController : ControllerBase
    {
        private readonly bibliotecaContext _bibliotecaContext;

        public bibliotecaController(bibliotecaContext bibliotecaContext) 
        {
            _bibliotecaContext = bibliotecaContext;
        }
    }
}
