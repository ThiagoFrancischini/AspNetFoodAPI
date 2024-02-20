using Microsoft.AspNetCore.Mvc;
using NetRestaurantAPI.Models;
using NetRestaurantAPI.Repositories;

namespace NetRestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioApiController : Controller
    {
        private UsuarioRepository usuarioRepository;
        public UsuarioApiController(Contexto contexto)
        {
            usuarioRepository = new UsuarioRepository(contexto);    
        }

        [HttpPost]
        public ActionResult<Usuario> Inserir(Usuario usuario)
        {
            try
            {
                usuarioRepository.InsereUsuario(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public ActionResult<Usuario> Autenticar(string cpf, string password)
        {
            try
            {
                var usuario = usuarioRepository.Autenticar(cpf, password);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
