using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LR_Projeto_Api.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("setup")]
    public class SetupController : Controller
    {
        private readonly AppDbContext _context;

        public SetupController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaSetups = await _context.Setups.ToListAsync();
                return Ok(listaSetups);
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
                var setup = await _context.Setups.FindAsync(id);

                if (setup == null)
                {
                    return NotFound($"Setup #{id} não encontrado");
                }

                return Ok(setup);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SetupDTO item)
        {
            try
            {
                var setup = new Setup()
                {
                    Unidade = item.Unidade,
                    Nome = item.Nome,
                    Valor = item.Valor,
                    Descricao = item.Descricao
                };
                await _context.Setups.AddAsync(setup);
                await _context.SaveChangesAsync();

                return Created("", setup);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SetupDTO item)
        {
            try
            {
                var setup = await _context.Setups.FindAsync(id);

                if (setup is null)
                {
                    return NotFound();
                }

                setup.Unidade = item.Unidade;
                setup.Nome = item.Nome;
                setup.Valor = item.Valor;
                setup.Descricao = item.Descricao;

                _context.Setups.Update(setup);
                await _context.SaveChangesAsync();

                return Ok(setup);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var setup = await _context.Setups.FindAsync(id);

                if (setup == null)
                {
                    return NotFound();
                }

                _context.Setups.Remove(setup);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}