using Microsoft.AspNetCore.Mvc;
using NetRestaurantAPI.Enums;
using NetRestaurantAPI.Models;
using NetRestaurantAPI.Repositories;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace NetRestaurantAPI.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoApiController : Controller
    {
        private PedidoRepository pedidoRepository;
        public PedidoApiController(Contexto contexto)
        {
            pedidoRepository = new PedidoRepository(contexto);
        }

        [HttpPost]
        public ActionResult InserePedido(Pedido pedido)
        {
            try
            {
                pedidoRepository.InserePedido(pedido);

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userid}")]
        public ActionResult<List<Pedido>> BuscaPedidos(Guid userId)
        {
            try
            {
                if(userId == Guid.Empty)
                {
                    throw new Exception("Nenhum usuario encontrado");
                }

                var lista = pedidoRepository.ProcuraPedidosPorUsuario(userId).Result;

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("AlteraStatusPedido")]
        public ActionResult AlteraStatusPedido(Pedido pedido)
        {
            try
            {
                if (pedido.Id == Guid.Empty)
                {
                    throw new Exception("Nenhum usuario encontrado");
                }

                pedidoRepository.AlteraStatusPedido(pedido);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
