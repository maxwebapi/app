using AppApi.Data;
using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.PedidoItem;
using MaxWebApi.Repositorios.Interfaces.PedidoItem;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.PedidoItem
{
    public class PedidoItemRepositorio : IPedidoItemRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public PedidoItemRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<PedidoItemModel>> BuscarPorPedido(Guid id)
        {
            return await _dbContext.PedidoItem
                .Include(x => x.Produto)
                .Where(x => x.PedidoId == id)
                .ToListAsync();
        }

        public async Task<PedidoItemModel> BuscarPorId(int id)
        {
            return await _dbContext.PedidoItem
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PedidoItemModel> Adicionar(PedidoItemModel pedidoItem)
        {
            await _dbContext.PedidoItem.AddAsync(pedidoItem);
            await _dbContext.SaveChangesAsync();

            PedidoItemModel novoPedidoItem = new PedidoItemModel();
            novoPedidoItem = await BuscarPorId(novoPedidoItem.Id);

            return novoPedidoItem;
        }

        public async Task<bool> Apagar(int id)
        {
            PedidoItemModel pedidoItemPorId = await BuscarPorId(id);
            if (pedidoItemPorId == null)
            {
                throw new Exception($"Pedido item para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.PedidoItem.Remove(pedidoItemPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
