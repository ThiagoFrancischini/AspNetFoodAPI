using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/Menu")]
    [ApiController]
    public class MenuApiController : Controller
    {
        private MenuRepository menuRepository { get; set; }
        public MenuApiController()
        {
            menuRepository = new MenuRepository();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<Menu> ProcuraMenu()
        {
            try
            {
                return Ok(menuRepository.ProcuraMenu());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
