using AppApi.Data;
using MaxWebApi.Models.Generico;
using MaxWebApi.Repositorios.Interfaces.Generico;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Cidade
{
    public class CidadeRepositorio : ICidadeRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public CidadeRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<CidadeModel>> BuscarTodas()
        {
            return await _dbContext.Cidade
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<CidadeModel> BuscarPorId(int id)
        {
            return await _dbContext.Cidade.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CidadeModel> BuscarPorNome(string nome)
        {
            return await _dbContext.Cidade.FirstOrDefaultAsync(x => x.Nome.Equals(nome));
        }

    }
}
