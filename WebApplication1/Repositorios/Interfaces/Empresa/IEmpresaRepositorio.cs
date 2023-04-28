using MaxWebApi.Models.Empresa;

namespace MaxWebApi.Repositorios.Interfaces.Empresa
{
    public interface IEmpresaRepositorio
    {
        Task<List<EmpresaModel>> BuscarTodas();
        Task<EmpresaModel> BuscarPorId(int id);
        Task<EmpresaModel> BuscarPorNome(string nome);
        Task<EmpresaModel> Adicionar(EmpresaModel usuario);
        Task<EmpresaModel> Atualizar(EmpresaModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
