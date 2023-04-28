using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Repositorios.Interfaces.Pessoa
{
    public interface IPessoaContribuinteRepositorio
    {
        Task<List<PessoaContribuinteModel>> BuscarTodos();
        Task<PessoaContribuinteModel> BuscarPorId(int id);
    }
}
