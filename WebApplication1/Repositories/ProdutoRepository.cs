using NetRestaurantAPI.Models;
using WebApplication1.Models;

namespace NetRestaurantAPI.Repositories
{
    public class ProdutoRepository(Contexto contexto)
    {
        public void InsereProduto(Product produto)
        {            
            produto.Id = Guid.NewGuid();

            produto.EntidadeValida();

            contexto.Produtos.AddAsync(produto);

            contexto.SaveChanges();                        
        }

        public Product DetalhesProduto(Guid id)
        {
            
            if(id == Guid.Empty) 
            {
                throw new Exception("Informe um identificador de produto válido");
            }

            var produto =  contexto.Produtos.SingleOrDefault(produto => produto.Id == id);            

            if(produto == null) 
            {
                throw new Exception("Produto não encontrado");
            }

            return produto; 
        }
    }
}
