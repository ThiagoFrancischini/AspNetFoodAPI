using Microsoft.AspNetCore.Mvc;
using NetRestaurantAPI.Models;
using NetRestaurantAPI.Repositories;
using WebApplication1.Models;

namespace NetRestaurantAPI.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoApiController : Controller
    {
        private ProdutoRepository produtoRepository;
        public ProdutoApiController(Contexto contexto)
        {
            produtoRepository = new ProdutoRepository(contexto);
        }

        [HttpPost]
        public ActionResult InsereProduto(Product produto)
        {
            try
            {
                produtoRepository.InsereProduto(produto);

                return Ok(produto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> BuscaProduto(Guid id) 
        {
            try
            {
                return produtoRepository.DetalhesProduto(id);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
