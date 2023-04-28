using AppApi.Data;
using MaxWebApi.Models.Empresa;
using MaxWebApi.Repositorios.Interfaces.Empresa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Empresa
{
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public EmpresaRepositorio(MaxWebApiDBContext maxWebApiDBContext)

        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<EmpresaModel>> BuscarTodas()
        {
            return await _dbContext.Empresa
                .Include(x => x.Situacao)
                .ToListAsync();            
        }

        public async Task<EmpresaModel> BuscarPorId(int id)
        {
            return await _dbContext.Empresa
                .Include(x => x.Situacao)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmpresaModel> BuscarPorNome(string nome)
        {
            return await _dbContext.Empresa
                .Include(x => x.Situacao)
                .FirstOrDefaultAsync(x => x.Nome.Equals(nome));
        }

        public async Task<EmpresaModel> Adicionar(EmpresaModel empresa)
        {
            await _dbContext.Empresa.AddAsync(empresa);
            await _dbContext.SaveChangesAsync();

            return empresa;
        }

        public async Task<EmpresaModel> Atualizar(EmpresaModel empresa, int id)
        {
            EmpresaModel empresaSalvar = await BuscarPorId(id);
            if (empresaSalvar == null)
            {
                throw new Exception($"Empresa para o ID: {id} não foi encontrado no banco de dados...");
            }
            empresaSalvar.Nome = empresa.Nome;
            empresaSalvar.SituacaoId = empresa.SituacaoId;

            _dbContext.Empresa.Update(empresaSalvar);
            await _dbContext.SaveChangesAsync();

            return empresaSalvar;
        }

        public async Task<bool> Apagar(int id)
        {
            EmpresaModel empresaPorId = await BuscarPorId(id);
            if (empresaPorId == null)
            {
                throw new Exception($"Empresa para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.Empresa.Remove(empresaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
