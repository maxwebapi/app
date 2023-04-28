
using MaxWebApi.Models.Produto;

namespace MaxWebApi.Repositorios.Interfaces.Produto
{
    public interface IProdutoGrupoRepositorio
    {
        Task<List<ProdutoGrupoModel>> BuscarTodos();
        Task<List<ProdutoGrupoModel>> BuscarPorEmpresa(int empresaId);
        Task<ProdutoGrupoModel> BuscarPorId(int id);
        Task<ProdutoGrupoModel> BuscarPorNome(string nome);
        Task<ProdutoGrupoModel> Adicionar(ProdutoGrupoModel produtoGrupo);
        Task<ProdutoGrupoModel> Atualizar(ProdutoGrupoModel produtoGrupo, int id);
        Task<bool> Apagar(int id);
    }
}
