using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetRestaurantAPI.Models;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuApiController : Controller
    {
        private MenuRepository menuRepository { get; set; }
        public MenuApiController(Contexto contexto)
        {
            menuRepository = new MenuRepository(contexto);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<Menu>> ProcuraMenu()
        {
            try
            {
                return Ok(menuRepository.ProcuraMenu().Result.First().Categorias);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult InsereMenu(Menu menu)
        {
            try
            {               
                menuRepository.InsereMenu(menu);

                return Ok(menu);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
