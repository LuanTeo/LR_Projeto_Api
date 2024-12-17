using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("estado")]
    public class EstadoController : Controller
    {
        private readonly AppDbContext _context;

        public EstadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaEstados = await _context.Estados.ToListAsync();

                return Ok(listaEstados);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
