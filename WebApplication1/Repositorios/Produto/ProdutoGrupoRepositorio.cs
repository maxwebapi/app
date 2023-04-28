using AppApi.Data;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Models.Produto;
using MaxWebApi.Repositorios.Interfaces.Produto;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Produto
{
    public class ProdutoGrupoRepositorio : IProdutoGrupoRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public ProdutoGrupoRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<ProdutoGrupoModel>> BuscarTodos()
        {
            return await _dbContext.ProdutoGrupo.ToListAsync();
        }

        public async Task<List<ProdutoGrupoModel>> BuscarPorEmpresa(int empresaId)
        {
            return await _dbContext.ProdutoGrupo
                .Include(x => x.Empresa)
                .Where(x => x.EmpresaId == empresaId || x.Id == 0)
                .OrderBy(x => x.ProdutoGrupo)
                .ToListAsync();
        }

        public async Task<ProdutoGrupoModel> BuscarPorId(int id)
        {
            return await _dbContext.ProdutoGrupo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProdutoGrupoModel> BuscarPorNome(string nome)
        {
            return await _dbContext.ProdutoGrupo.FirstOrDefaultAsync(x => x.ProdutoGrupo == nome);
        }

        public async Task<ProdutoGrupoModel> Adicionar(ProdutoGrupoModel produtoGrupo)
        {
            await _dbContext.ProdutoGrupo.AddAsync(produtoGrupo);
            await _dbContext.SaveChangesAsync();

            ProdutoGrupoModel novProdutoGrupo = new ProdutoGrupoModel();
            novProdutoGrupo = await BuscarPorId(produtoGrupo.Id);

            return novProdutoGrupo;
        }

        public async Task<ProdutoGrupoModel> Atualizar(ProdutoGrupoModel produtoGrupo, int id)
        {
            ProdutoGrupoModel produtoGrupoSalvar = await BuscarPorId(id);
            if (produtoGrupoSalvar == null)
            {
                throw new Exception($"Grupo de Produto para o ID: {id} não foi encontrado no banco de dados...");
            }
            produtoGrupoSalvar.ProdutoGrupo = produtoGrupo.ProdutoGrupo;

            _dbContext.ProdutoGrupo.Update(produtoGrupoSalvar);
            await _dbContext.SaveChangesAsync();

            ProdutoGrupoModel novoProdutoGrupo = new ProdutoGrupoModel();
            novoProdutoGrupo = await BuscarPorId(novoProdutoGrupo.Id);

            return novoProdutoGrupo;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoGrupoModel produtoGrupoPorId = await BuscarPorId(id);
            if (produtoGrupoPorId == null)
            {
                throw new Exception($"Grupo de Produto para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.ProdutoGrupo.Remove(produtoGrupoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
