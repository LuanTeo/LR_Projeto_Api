using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("componente")]
    public class ComponenteController : Controller
    {
        private readonly AppDbContext _context;

        public ComponenteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaComponentes = await _context.Componentes.ToListAsync();

                return Ok(listaComponentes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
