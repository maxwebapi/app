using AppApi.Data;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Pessoa
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public PessoaRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<PessoaModel>> BuscarTodas()
        {
            return await _dbContext.Pessoa
                .Include(x => x.Empresa)
                .Include(x => x.PessoaTipo)
                .Include(x => x.PessoaContribuinte)
                .Include(x => x.Situacao)
                .Include(x => x.Cidade)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<List<PessoaModel>> BuscarPorEmpresa(int empresaId)
        {
            return await _dbContext.Pessoa
                .Include(x => x.Empresa)
                .Include(x => x.PessoaTipo)
                .Include(x => x.PessoaContribuinte)
                .Include(x => x.Situacao)
                .Include(x => x.Cidade)
                .Where(x => x.EmpresaId == empresaId)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
        public async Task<List<PessoaModel>> BuscarClientePorEmpresa(int empresaId)
        {
            return await _dbContext.Pessoa
                .Include(x => x.Empresa)
                .Include(x => x.PessoaTipo)
                .Include(x => x.PessoaContribuinte)
                .Include(x => x.Situacao)
                .Include(x => x.Cidade)
                .Where(x => x.EmpresaId == empresaId && x.Cliente.Equals("S"))
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }
        public async Task<List<PessoaModel>> BuscarVendedorPorEmpresa(int empresaId)
        {
            return await _dbContext.Pessoa
                .Include(x => x.Empresa)
                .Include(x => x.PessoaTipo)
                .Include(x => x.PessoaContribuinte)
                .Include(x => x.Situacao)
                .Include(x => x.Cidade)
                .Where(x => x.EmpresaId == empresaId && x.Vendedor.Equals("S"))
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<PessoaModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Pessoa
                .Include(x => x.Empresa)
                .Include(x => x.PessoaTipo)
                .Include(x => x.PessoaContribuinte)
                .Include(x => x.Situacao)
                .Include(x => x.Cidade)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PessoaModel> BuscarPorNome(string nome)
        {
            return await _dbContext.Pessoa
                .Include(x => x.Empresa)
                .Include(x => x.PessoaTipo)
                .Include(x => x.PessoaContribuinte)
                .Include(x => x.Situacao)
                .Include(x => x.Cidade)
                .FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<PessoaModel> Adicionar(PessoaModel pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            PessoaModel novaPessoa = new PessoaModel();
            novaPessoa = await BuscarPorId(pessoa.Id);

            return novaPessoa;
        }

        public async Task<PessoaModel> Atualizar(PessoaModel pessoa, Guid id)
        {
            PessoaModel pessoaSalvar = await BuscarPorId(id);
            if (pessoaSalvar == null)
            {
                throw new Exception($"Pessoa para o ID: {id} não foi encontrado no banco de dados...");
            }
            pessoaSalvar.Nome = pessoa.Nome;
            pessoaSalvar.PessoaId = pessoa.PessoaId;
            pessoaSalvar.EmpresaId = pessoa.EmpresaId;
            pessoaSalvar.PessoaTipoId = pessoa.PessoaTipoId;
            pessoaSalvar.PessoaContribuinteId = pessoa.PessoaContribuinteId;
            pessoaSalvar.SituacaoId = pessoa.SituacaoId;
            pessoaSalvar.CidadeId = pessoa.CidadeId;
            pessoaSalvar.Bairro = pessoa.Bairro;
            pessoaSalvar.Endereco = pessoa.Endereco;
            pessoaSalvar.Numero = pessoa.Numero;
            pessoaSalvar.Complemento = pessoa.Complemento;
            pessoaSalvar.Email = pessoa.Email;
            pessoaSalvar.Cpf = pessoa.Cpf;
            pessoaSalvar.Rg = pessoa.Rg;
            pessoaSalvar.Cnpj = pessoa.Cnpj;
            pessoaSalvar.Ie = pessoa.Ie;
            pessoaSalvar.TelComercial = pessoa.TelComercial;
            pessoaSalvar.TelContato = pessoa.TelContato;
            pessoaSalvar.TelCelular = pessoa.TelCelular;
            pessoaSalvar.Cliente = pessoa.Cliente;
            pessoaSalvar.Vendedor = pessoa.Vendedor;

            _dbContext.Pessoa.Update(pessoaSalvar);
            await _dbContext.SaveChangesAsync();

            PessoaModel novaPessoa = new PessoaModel();
            novaPessoa = await BuscarPorId(pessoa.Id);

            return novaPessoa;
        }

        public async Task<bool> Apagar(Guid id)
        {
            PessoaModel pessoaPorId = await BuscarPorId(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Pessoa para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.Pessoa.Remove(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
