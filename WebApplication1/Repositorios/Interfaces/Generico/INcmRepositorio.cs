using MaxWebApi.Models.Generico;

namespace MaxWebApi.Repositorios.Interfaces.Generico
{
    public interface INcmRepositorio
    {
        Task<List<NcmModel>> BuscarTodos();
        Task<NcmModel> BuscarPorId(int id);
        Task<NcmModel> BuscarPorDescricao(string descricao);
    }
}
