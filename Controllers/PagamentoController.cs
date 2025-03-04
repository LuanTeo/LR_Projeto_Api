using LR_Projeto_Api.DataContext;
using LR_Projeto_Api.Models;
using LR_Projeto_Api.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LR_Projeto_Api.Controllers
{
    [ApiController]
    [Route("pagamento")]
    public class PagamentoController : Controller
    {
        private readonly AppDbContext _context;

        public PagamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPagamentos = await _context.Pagamentos
                    .Include(p => p.Carrinho)
                    .Select(p => new
                    {
                        p.Id,
                        p.FormaPagamento,
                        p.DataPagamento,
                        Carrinho = p.Carrinho != null ? new { p.Carrinho.Id, p.Carrinho.Valor} : null
                    })
                    .ToListAsync();

                return Ok(listaPagamentos);
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
                var pagamento = await _context.Pagamentos
                    .Include(p => p.Carrinho)
                    .Where(p => p.Id == id)
                    .Select(p => new
                    {
                        p.Id,
                        p.FormaPagamento,
                        p.DataPagamento,
                        Carrinho = p.Carrinho != null ? new { p.Carrinho.Id, p.Carrinho.Valor } : null
                    })
                    .FirstOrDefaultAsync();

                if (pagamento == null)
                {
                    return NotFound($"Pagamento #{id} não encontrado");
                }

                return Ok(pagamento);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PagamentoDTO item)
        {
            try
            {
                if (!await CarrinhoExist(item.CarrinhoId))
                {
                    return BadRequest("O Carrinho fornecido não existe!");
                }

                var pagamento = new Pagamento()
                {
                    FormaPagamento = item.FormaPagamento,
                    DataPagamento = item.DataPagamento
                };

                await _context.Pagamentos.AddAsync(pagamento);
                await _context.SaveChangesAsync();

                return Created("", pagamento);
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
                var pagamento = await _context.Pagamentos.FindAsync(id);

                if (pagamento == null)
                {
                    return NotFound();
                }

                _context.Pagamentos.Remove(pagamento);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        private async Task<bool> CarrinhoExist(int id)
        {
            return await _context.Carrinho.AnyAsync(c => c.Id == id);
        }
    }
}