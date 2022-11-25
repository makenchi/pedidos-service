using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pedidoServiceApi.Data;
using pedidoServiceApi.DTO;
using pedidoServiceApi.Models;
using System.Linq;

namespace pedidoServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Pedido>>> Get() 
        {
            return Ok(await _context.Pedidos.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult> Add(AddPedidoDTO pedido)
        {
            if (pedido.ItensDoPedido == null || pedido.ItensDoPedido.Count < 1)
            {
                return BadRequest("Pedido precisa ao menos ter um item.");
            }

            var client = await _context.Clientes.FindAsync(pedido.IdCliente);
            if (client == null)
            {
                return BadRequest("Pedido precisa de um cliente existente.");
            }

            //criando pedido
            _context.Pedidos.Add(new Pedido{
                NumeroDoPedido = pedido.NumeroDoPedido,
                idClinte = pedido.IdCliente,
                DataDeCriacao = DateTime.Now
            });

            foreach (var itenPedido in pedido.ItensDoPedido)
            {
                _context.ItensPedidos.Add(new ItemPedido
                {
                    Nome = itenPedido.Nome,
                    ValorUnitario = itenPedido.ValorUnitario,
                    NumeroDoPedido = pedido.NumeroDoPedido
                });
            }

            _context.SaveChangesAsync();

            return Ok("Pedido inserido com sucesso.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddPedidoDTO>> Get(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return BadRequest("Pedido não encontrado.");
            }

            var itensDoPedido = await _context.ItensPedidos.Where(
                x => x.NumeroDoPedido == pedido.NumeroDoPedido).ToListAsync();

            AddPedidoDTO pedidoDTO = new AddPedidoDTO
            {
                IdCliente = pedido.idClinte,
                NumeroDoPedido = pedido.NumeroDoPedido,
                ItensDoPedido = itensDoPedido
            };

            return Ok(pedido);
        }
    }
}
