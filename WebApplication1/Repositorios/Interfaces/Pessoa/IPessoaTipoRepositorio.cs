using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Repositorios.Interfaces.Pessoa
{
    public interface IPessoaTipoRepositorio
    {
        Task<List<PessoaTipoModel>> BuscarTodos();
        Task<PessoaTipoModel> BuscarPorId(int id);
    }
}
