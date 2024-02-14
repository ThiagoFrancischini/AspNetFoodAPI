using Microsoft.EntityFrameworkCore;
using NetRestaurantAPI.Models;
using WebApplication1.Models;

namespace NetRestaurantAPI.Repositories
{    
    public class CategoriaRepository(Contexto contexto)
    {        
        public async void InsereCategoria(Categoria categoria)
        {
            if(categoria.Menu ==  null) 
            {
                //Em teoria como essa é uma API de apoio eu não queria perder tanto tempo nela, então fiz um fluxo que em teoria só deixe o usuário criar um Menu

                categoria.Menu = new Menu { Id = contexto.Menu.ToListAsync().Result.First().Id };
            }

            categoria.Id = Guid.NewGuid();

            await contexto.Categorias.AddAsync(categoria);

            await contexto.SaveChangesAsync();
        }
    }
}
