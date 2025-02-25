using LR_Projeto_Api.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LR_Projeto_Api.DTO;
using LR_Projeto_Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

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
                var componente = await _context.Componentes.Where(s => s.Id == id).FirstOrDefaultAsync();

                if (componente == null)
                {
                    return NotFound($"Componente #{id} não encontrado");
                }

                return Ok(componente);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComponenteDTO item)
        {
            try
            {

                var componentes = new Componente()
                {
                    Nome = item.Nome,
                    Especificacao = item.Especificacao,
                    Link = item.Link,
                    Valor = item.Valor,
                    Unidade = item.Unidade
                };

                await _context.Componentes.AddAsync(componentes);
                await _context.SaveChangesAsync();

                return Created("", componentes);
            }
            catch (Exception e)
            {
                return Problem();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ComponenteDTO item)
        {
            try
            {
                var componente = await _context.Componentes.FindAsync(id);

                if (componente is null)
                {
                    return NotFound();
                }

                componente.Nome = item.Nome;
                componente.Especificacao = item.Especificacao;
                componente.Link = item.Link;
                componente.Valor = item.Valor;
                componente.Unidade = item.Unidade;

                _context.Componentes.Update(componente);
                await _context.SaveChangesAsync();

                return Ok(componente);
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
                var componente = await _context.Componentes.FindAsync(id);

                if (componente is null)
                {
                    return NotFound();
                }

                _context.Componentes.Remove(componente);
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
