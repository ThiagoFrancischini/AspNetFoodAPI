using Microsoft.AspNetCore.Mvc;
using NetRestaurantAPI.Models;
using NetRestaurantAPI.Repositories;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace NetRestaurantAPI.Controllers
{
    [Route("api/categoria")]
    [ApiController] 
    public class CategoriaApiController : Controller
    {
        private CategoriaRepository categoriaRepository { get; set; }
        public CategoriaApiController(Contexto contexto)
        {
            categoriaRepository = new CategoriaRepository(contexto);
        }

        [HttpPost] 
        public ActionResult InsereCategoria(Categoria categoria)
        {
            try
            {
                if(categoria == null) 
                {
                    throw new Exception();
                }

                categoriaRepository.InsereCategoria(categoria);

                return Ok(categoria);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
