using NetRestaurantAPI.Models;

namespace NetRestaurantAPI.Repositories
{
    public class UsuarioRepository(Contexto contexto)
    {
        public void InsereUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();

            usuario.EntidadeValida();

            usuario.LimpaCpf();

            if (contexto.Usuarios.Where(user => user.Cpf == usuario.Cpf).ToList().Count > 0)
            {
                throw new Exception("Usuário com este CPF já cadastrado!");
            }            

            contexto.Usuarios.Add(usuario);

            contexto.SaveChanges();
        }

        public Usuario Autenticar(string cpf, string password)
        {
            var usuario = contexto.Usuarios.Where(user => user.Cpf == cpf &&  user.Password.Trim() == password.Trim()).FirstOrDefault();
            
            if(usuario != null)
            {
                usuario.Autenticado = true;
                return usuario;
            }

            throw new Exception("Usuário não encontrado!");
        }
    }
}
