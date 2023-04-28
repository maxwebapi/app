using MaxWebApi.Models.Produto;

namespace MaxWebApi.Repositorios.Interfaces.Produto
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodos();
        Task<List<ProdutoModel>> BuscarPorEmpresa(int empresaId);
        Task<ProdutoModel> BuscarPorId(Guid id);
        Task<ProdutoModel> BuscarPorNome(string Nome);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
