using MaxWebApi.Models.Generico;

namespace MaxWebApi.Repositorios.Interfaces.Generico
{
    public interface ICidadeRepositorio
    {
        Task<List<CidadeModel>> BuscarTodas();
        Task<CidadeModel> BuscarPorId(int id);
        Task<CidadeModel> BuscarPorNome(string nome);
    }
}
