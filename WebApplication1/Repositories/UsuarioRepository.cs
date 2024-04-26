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
                throw new ApplicationException("Usuário com este CPF já cadastrado!");
            }            

            contexto.Usuarios.Add(usuario);

            contexto.SaveChanges();
        }

        public Usuario Autenticar(string cpf, string password)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            var usuario = contexto.Usuarios.Where(user => user.Cpf == cpf &&  user.Password.Trim() == password.Trim()).FirstOrDefault();
            
            if(usuario != null)
            {
                usuario.Autenticado = true;
                return usuario;
            }

            throw new ApplicationException("Usuário não encontrado!");
        }

        public void InsereTokenNotificacao(NotificationTokens notificationToken)
        {
            if(contexto.NotificationTokens.Where(x=> x.ExpoToken == notificationToken.ExpoToken).Any())
            {
                return;
            }

            if (contexto.NotificationTokens.Where(x=> x.UsuarioId == notificationToken.UsuarioId).Any())
            {                                
                contexto.NotificationTokens.Update(notificationToken);
            }
            else
            {
                contexto.NotificationTokens.Add(notificationToken);
            }            

            contexto.SaveChanges();            
        }
    }
}
