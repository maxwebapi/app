using AppApi.Data;
using MaxWebApi.Models.Generico;
using MaxWebApi.Repositorios.Interfaces.Generico;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Situacao
{
    public class SituacaoRepositorio : ISituacaoRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public SituacaoRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<SituacaoModel>> BuscarTodas()
        {
            return await _dbContext.Situacao.ToListAsync();
        }

        public async Task<SituacaoModel> BuscarPorId(int id)
        {
            return await _dbContext.Situacao.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
