using AppApi.Data;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Pessoa
{
    public class PessoaTipoRepositorio : IPessoaTipoRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public PessoaTipoRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<PessoaTipoModel> BuscarPorId(int id)
        {
            return await _dbContext.PessoaTipo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PessoaTipoModel>> BuscarTodos()
        {
            return await _dbContext.PessoaTipo.ToListAsync();
        }
    }
}
