using NetRestaurantAPI.Helpers;

namespace NetRestaurantAPI.Models
{
    public class Usuario
    {        
        public Usuario()
        {
            Email = string.Empty;
            Nome = string.Empty;
            Cpf = string.Empty;            
            Password = string.Empty;
            Endereco = string.Empty;
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string Endereco { get; set; }
        public bool Autenticado { get; set; }
        public string Telefone { get; set; }
        public void EntidadeValida()
        {
            if(Id == Guid.Empty) 
            {
                throw new Exception("Informe um Id!");
            }

            if(string.IsNullOrEmpty(Email)) 
            {
                throw new Exception("Informe um email!");
            }

            if (string.IsNullOrEmpty(Nome))
            {
                throw new Exception("Informe um email!");
            }

            if (string.IsNullOrEmpty(Cpf))
            {
                throw new Exception("Informe um email!");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Informe um email!");
            }

            if (string.IsNullOrEmpty(Endereco))
            {
                throw new Exception("Informe um email!");
            }

            if (string.IsNullOrEmpty(Telefone) || this.Telefone.Length < 9)
            {
                throw new Exception("Informe um telefone válido!");
            }
        }

        public void LimpaCpf()
        {
            this.Cpf = StringHelpers.LimpaCpf(this.Cpf);
        }
    }
}
