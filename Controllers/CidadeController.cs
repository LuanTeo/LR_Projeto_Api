using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("cidade")]
    public class CidadeController : Controller
    {
        private readonly AppDbContext _context;

        public CidadeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaCidades = await _context.Cidades
                    .Include(e => e.Estado)
                    .Select(e => new {
                        e.Id,
                        e.Nome,
                        Estado = new { e.Estado.Id, e.Estado.Nome, e.Estado.Uf }
                    })
                    .ToListAsync();

                return Ok(listaCidades);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
