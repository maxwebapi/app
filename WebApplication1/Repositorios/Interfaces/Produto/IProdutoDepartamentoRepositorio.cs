using MaxWebApi.Models.Produto;

namespace MaxWebApi.Repositorios.Interfaces.Produto
{
    public interface IProdutoDepartamentoRepositorio
    {
        Task<List<ProdutoDepartamentoModel>> BuscarTodos();
        Task<List<ProdutoDepartamentoModel>> BuscarPorEmpresa(int empresaId);
        Task<ProdutoDepartamentoModel> BuscarPorId(int id);
        Task<ProdutoDepartamentoModel> BuscarPorNome(string nome);
        Task<ProdutoDepartamentoModel> Adicionar(ProdutoDepartamentoModel produtoDepartamento);
        Task<ProdutoDepartamentoModel> Atualizar(ProdutoDepartamentoModel produtoDepartamento, int id);
        Task<bool> Apagar(int id);
    }
}
