using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Repositorios.Interfaces.Pessoa
{
    public interface IPessoaRepositorio
    {
        Task<List<PessoaModel>> BuscarTodas();
        Task<List<PessoaModel>> BuscarPorEmpresa(int empresaId);
        Task<List<PessoaModel>> BuscarClientePorEmpresa(int empresaId);
        Task<List<PessoaModel>> BuscarVendedorPorEmpresa(int empresaId);
        Task<PessoaModel> BuscarPorId(Guid id);
        Task<PessoaModel> BuscarPorNome(string nome);
        Task<PessoaModel> Adicionar(PessoaModel pessoa);
        Task<PessoaModel> Atualizar(PessoaModel pessoa, Guid id);
        Task<bool> Apagar(Guid id);
    }
}
