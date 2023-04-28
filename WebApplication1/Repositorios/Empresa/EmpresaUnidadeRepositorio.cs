using AppApi.Data;
using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Empresa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Empresa
{
    public class EmpresaUnidadeRepositorio : IEmpresaUnidadeRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public EmpresaUnidadeRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<EmpresaUnidadeModel>> BuscarTodas()
        {
            return await _dbContext.EmpresaUnidade
                .Include(x => x.Empresa)
                .ToListAsync();
        }

        public async Task<List<EmpresaUnidadeModel>> BuscarUnidadePorEmpresa(int empresaId)
        {
            return await _dbContext.EmpresaUnidade
                .Include(x => x.Empresa)
                .Where(x => x.EmpresaId == empresaId)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<EmpresaUnidadeModel> BuscarPorId(int id)
        {
            return await _dbContext.EmpresaUnidade
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmpresaUnidadeModel> BuscarPorNome(string nome)
        {
            return await _dbContext.EmpresaUnidade
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Nome.Equals(nome));
        }

        public async Task<EmpresaUnidadeModel> Adicionar(EmpresaUnidadeModel empresaUnidade)
        {
            await _dbContext.EmpresaUnidade.AddAsync(empresaUnidade);
            await _dbContext.SaveChangesAsync();

            EmpresaUnidadeModel novaEmpresaUnidade = new EmpresaUnidadeModel();
            novaEmpresaUnidade = await BuscarPorId(empresaUnidade.Id);

            return novaEmpresaUnidade;
        }

        public async Task<EmpresaUnidadeModel> Atualizar(EmpresaUnidadeModel empresaUnidade, int id)
        {
            EmpresaUnidadeModel empresaUnidadeSalvar = await BuscarPorId(id);
            if (empresaUnidadeSalvar == null)
            {
                throw new Exception($"Empresa para o ID: {id} não foi encontrado no banco de dados...");
            }
            empresaUnidade.Nome = empresaUnidade.Nome;
            empresaUnidade.EmpresaId = empresaUnidade.EmpresaId;
            empresaUnidade.Nome = empresaUnidade.Nome;
            empresaUnidade.CidadeId = empresaUnidade.CidadeId;
            empresaUnidade.Cep = empresaUnidade.Cep;
            empresaUnidade.Bairro = empresaUnidade.Bairro;
            empresaUnidade.Endereco = empresaUnidade.Endereco;
            empresaUnidade.Numero = empresaUnidade.Numero;
            empresaUnidade.Complemento = empresaUnidade.Complemento;
            empresaUnidade.Email = empresaUnidade.Email;
            empresaUnidade.Cnpj = empresaUnidade.Cnpj;
            empresaUnidade.Ie = empresaUnidade.Ie;

            _dbContext.EmpresaUnidade.Update(empresaUnidadeSalvar);
            await _dbContext.SaveChangesAsync();

            EmpresaUnidadeModel novaEmpresaUnidade = new EmpresaUnidadeModel();
            novaEmpresaUnidade = await BuscarPorId(empresaUnidade.Id);

            return novaEmpresaUnidade;
        }

        public async Task<bool> Apagar(int id)
        {
            EmpresaUnidadeModel empresaUnidadePorId = await BuscarPorId(id);
            if (empresaUnidadePorId == null)
            {
                throw new Exception($"Empresa para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.EmpresaUnidade.Remove(empresaUnidadePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
