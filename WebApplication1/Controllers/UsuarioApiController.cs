using Microsoft.AspNetCore.Mvc;
using NetRestaurantAPI.DTOs;
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
        public ActionResult<Usuario> Autenticar(LoginDTO login)
        {
            try
            {
                if(login == null || string.IsNullOrEmpty(login.Cpf) || string.IsNullOrEmpty(login.Cpf))
                {
                    throw new Exception("Dados Inválidos");
                }

                var usuario = usuarioRepository.Autenticar(login.Cpf, login.Password);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
