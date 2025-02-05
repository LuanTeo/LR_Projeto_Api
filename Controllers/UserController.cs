using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context) {

            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listUsuarios = await _context.Usuarios.ToListAsync();

                return Ok(listUsuarios);

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
                var usuario = await _context.Usuarios.Where(u => u.Id == id).FirstOrDefaultAsync();

                if (usuario == null) return NotFound();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
