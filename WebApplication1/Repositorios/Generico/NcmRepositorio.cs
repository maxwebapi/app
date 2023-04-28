using AppApi.Data;
using MaxWebApi.Models.Generico;
using MaxWebApi.Repositorios.Interfaces.Generico;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Ncm
{
    public class NcmRepositorio : INcmRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public NcmRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<NcmModel>> BuscarTodos()
        {
            return await _dbContext.Ncm.ToListAsync();
        }

        public async Task<NcmModel> BuscarPorId(int id)
        {
            return await _dbContext.Ncm.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<NcmModel> BuscarPorDescricao(string descricao)
        {
            return await _dbContext.Ncm.FirstOrDefaultAsync(x => x.Descricao.Equals(descricao));
        }

    }
}
