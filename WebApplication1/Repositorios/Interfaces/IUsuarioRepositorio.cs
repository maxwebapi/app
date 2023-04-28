using MaxWebApi.Models;

namespace MaxWebApi.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodos();
        Task<UsuarioModel> BuscarPorId(Guid id);
        Task<UsuarioModel> BuscarPorEmail(string email);
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, Guid id);
        Task<bool> Apagar(Guid id);

    }
}
