using NetRestaurantAPI.Models;
using WebApplication1.Models;

namespace NetRestaurantAPI.Repositories
{
    public class ProdutoRepository(Contexto contexto)
    {
        public void InsereProduto(Product produto)
        {            
            produto.Id = Guid.NewGuid();
            contexto.Produtos.AddAsync(produto);
        }
    }
}
