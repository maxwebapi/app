using MaxWebApi.Models.Generico;

namespace MaxWebApi.Repositorios.Interfaces.Generico
{
    public interface ISituacaoRepositorio
    {
        Task<List<SituacaoModel>> BuscarTodas();
        Task<SituacaoModel> BuscarPorId(int id);
    }
}
