using AppApi.Data;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Pessoa
{
    public class PessoaContriubinteRepositorio : IPessoaContribuinteRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public PessoaContriubinteRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<PessoaContribuinteModel> BuscarPorId(int id)
        {
            return await _dbContext.PessoaContribuinte.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PessoaContribuinteModel>> BuscarTodos()
        {
            return await _dbContext.PessoaContribuinte.ToListAsync();
        }
    }
}
