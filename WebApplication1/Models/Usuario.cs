using NetRestaurantAPI.Helpers;

namespace NetRestaurantAPI.Models
{
    public class Usuario
    {        
        public Usuario()
        {
            Id = Guid.Empty;
            Email = string.Empty;
            Nome = string.Empty;
            Cpf = string.Empty;            
            Password = string.Empty;
            Rua = string.Empty;
            Bairro = string.Empty;
            Cidade = string.Empty;
            Numero = string.Empty;
            Complemento = string.Empty;
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
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
                throw new Exception("Informe um Nome!");
            }

            if (string.IsNullOrEmpty(Cpf))
            {
                throw new Exception("Informe um Cpf!");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Informe uma Senha!");
            }

            if (string.IsNullOrEmpty(Rua) || string.IsNullOrEmpty(Bairro) || string.IsNullOrEmpty(Numero) || string.IsNullOrEmpty(Cidade))
            {
                throw new Exception("Informe um enedereço valido!");
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
