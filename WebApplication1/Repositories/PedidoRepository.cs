using Microsoft.EntityFrameworkCore;
using NetRestaurantAPI.Models;

namespace NetRestaurantAPI.Repositories
{
    public class PedidoRepository(Contexto contexto)
    {
        public void InserePedido(Pedido pedido)
        {
            if (pedido.Produtos == null || pedido.Produtos.Count == 0)
            {
                throw new Exception("Informe ao menos um produto");
            }

            pedido.Id = Guid.NewGuid();

            pedido.StatusPedido = Enums.MyEnums.enStatusPedido.EmAnalise;            

            pedido.Produtos.ForEach(p => pedido.PrecoTotal += p.Price);

            pedido.EntidadeValida();

            contexto.Pedidos.Add(pedido);

            contexto.SaveChanges();
        }

        public async Task<List<Pedido>> ProcuraPedidosPorUsuario(Guid userId)
        {            
            return await contexto.Pedidos.Where(p => p.Usuario.Id == userId).ToListAsync();
        }

        public async void AlteraStatusPedido(Pedido pedido)
        {
            Pedido pedidoVelho = await contexto.Pedidos.FindAsync(pedido.Id) ?? throw new Exception("Não foi encontrado nenhum pedido com o Id informado");

            pedidoVelho.StatusPedido = pedido.StatusPedido;

            contexto.Pedidos.Update(pedidoVelho);

            contexto.SaveChanges();
        }
    }
}
