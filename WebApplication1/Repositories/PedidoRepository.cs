using Microsoft.EntityFrameworkCore;
using NetRestaurantAPI.Enums;
using NetRestaurantAPI.Models;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace NetRestaurantAPI.Repositories
{
    public class PedidoRepository(Contexto contexto)
    {
        public void InserePedido(Pedido pedido)
        {
            try
            {
                contexto.Database.BeginTransaction();

                if (pedido.Produtos == null || pedido.Produtos.Count == 0)
                {
                    throw new Exception("Informe ao menos um produto");
                }

                pedido.Id = Guid.NewGuid();

                pedido.StatusPedido = Enums.MyEnums.enStatusPedido.EmAnalise;

                pedido.PrecoTotal = 0;

                pedido.Produtos.ForEach(p => pedido.PrecoTotal += p.Price);

                pedido.FotoEntrega = "";

                pedido.EntidadeValida();

                string sqlInsercaoPedido = " INSERT INTO Pedidos (Id, UsuarioId, DataInclusao, PrecoTotal, StatusPedido, FotoEntrega) VALUES (@p0, @p1, @p2, @p3, @p4, @p5) ";

                var parametrosPedido = new object[] { pedido.Id.ToString().ToUpper(), pedido.Usuario.Id.ToString().ToUpper(), pedido.DataInclusao, pedido.PrecoTotal, Convert.ToInt32(pedido.StatusPedido), pedido.FotoEntrega };

                contexto.Database.ExecuteSqlRaw(sqlInsercaoPedido, parametrosPedido);

                foreach (Product produto in pedido.Produtos)
                {
                    string sqlInsercaoRelacao = " INSERT INTO PedidoProduto (Id, PedidoId, ProdutoId) VALUES (@p0, @p1, @p2) ";

                    var parametrosRelacao = new object[] {Guid.NewGuid().ToString(), pedido.Id.ToString().ToUpper(), produto.Id.ToString().ToUpper() };

                    contexto.Database.ExecuteSqlRaw(sqlInsercaoRelacao, parametrosRelacao);
                }

                contexto.Database.CommitTransaction();                
            }
            catch (Exception ex)
            {
                contexto.Database.RollbackTransaction();

                throw ex;
            }            
        }

        public async Task<List<Pedido>> ProcuraPedidosPorUsuario(Guid userId)
        {
            List<Pedido> pedidos = await contexto.Pedidos.Where(p => p.Usuario.Id.ToString().ToUpper() == userId.ToString().ToUpper() && p.StatusPedido != MyEnums.enStatusPedido.Finalizado).OrderByDescending(x=> x.DataInclusao).ToListAsync();            

            if(pedidos != null && pedidos.Count > 0)
            {
                foreach(var pedido in pedidos) 
                {
                    string pedidoIdUpper = pedido.Id.ToString().ToUpper();

                    var produtos = contexto.Produtos.FromSqlRaw(" SELECT Produtos.Id AS ProdutoId, Produtos.CategoriaId, Produtos.Cover, Produtos.Description, Produtos.Ingredients, Produtos.Price, Produtos.Thumbnail, Produtos.Title, PedidoProduto.Id, PedidoProduto.PedidoId " +
                                                                " FROM Produtos " +
                                                                " INNER JOIN PedidoProduto on PedidoProduto.ProdutoId = Produtos.Id  " +
                                                                " WHERE UPPER(PedidoProduto.PedidoId)  = @p0 ", new object[] { pedido.Id.ToString().ToUpper() });                    

                    pedido.Produtos = produtos.ToList();
                }                
            }
            

            return pedidos;
        }

        public void AlteraStatusPedido(Pedido pedido)
        {
            contexto.Database.BeginTransaction();

            string sql = " update pedidos set StatusPedido = @p0 where id = @p1 ";

            var parametrosPedido = new object[] { Convert.ToInt32(pedido.StatusPedido), pedido.Id.ToString().ToUpper() };

            contexto.Database.ExecuteSqlRaw(sql, parametrosPedido);

            contexto.Database.CommitTransaction();
        }

        public void ConfirmaEntregaPedido(Pedido pedido)
        {
            contexto.Database.BeginTransaction();

            string sql = " update pedidos set StatusPedido = @p0, FotoEntrega = @p1 where id = @p2 ";

            var parametrosPedido = new object[] { Convert.ToInt32(MyEnums.enStatusPedido.Finalizado), pedido.FotoEntrega, pedido.Id.ToString().ToUpper() };

            contexto.Database.ExecuteSqlRaw(sql, parametrosPedido);

            contexto.Database.CommitTransaction();
        }
    }
}
