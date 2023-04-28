using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Repositorios.Interfaces.Pedido
{
    public interface IPedidoRepositorio
    {
        Task<List<PedidoModel>> BuscarTodos();
        Task<List<PedidoModel>> BuscarPorEmpresa(int empresaId);
        Task<List<PedidoModel>> BuscarPorEmpresaUnicade(int empresaId, int empresaUnidadeId);
        Task<PedidoModel> BuscarUltimoPedido(string usuarioId);
        Task<PedidoModel> BuscarPorId(Guid id);
        Task<PedidoModel> Adicionar(PedidoModel pedido);
        Task<PedidoModel> Atualizar(PedidoModel pedido, Guid id);
        Task<PedidoModel> EncerrarPedido(PedidoModel pedido, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
