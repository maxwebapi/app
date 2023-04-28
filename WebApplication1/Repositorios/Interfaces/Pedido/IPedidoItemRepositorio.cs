
using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.PedidoItem;

namespace MaxWebApi.Repositorios.Interfaces.PedidoItem
{
    public interface IPedidoItemRepositorio
    {
        Task<List<PedidoItemModel>> BuscarPorPedido(Guid pedidoId);
        Task<PedidoItemModel> BuscarPorId(int id);
        Task<PedidoItemModel> Adicionar(PedidoItemModel pedidoItem);
        Task<bool> Apagar(int id);

    }
}
