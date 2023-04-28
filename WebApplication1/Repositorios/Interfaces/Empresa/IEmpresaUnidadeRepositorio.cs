using MaxWebApi.Models.Empresa;

namespace MaxWebApi.Repositorios.Interfaces.Empresa
{
    public interface IEmpresaUnidadeRepositorio
    {
        Task<List<EmpresaUnidadeModel>> BuscarTodas();
        Task<EmpresaUnidadeModel> BuscarPorId(int id);
        Task<List<EmpresaUnidadeModel>> BuscarUnidadePorEmpresa(int empresaId);
        Task<EmpresaUnidadeModel> BuscarPorNome(string nome);
        Task<EmpresaUnidadeModel> Adicionar(EmpresaUnidadeModel empresaUnidade);
        Task<EmpresaUnidadeModel> Atualizar(EmpresaUnidadeModel empresaUnidade, int id);
        Task<bool> Apagar(int id);
    }
}
