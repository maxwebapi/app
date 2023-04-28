using AppApi.Data;
using MaxWebApi.Models.Produto;
using MaxWebApi.Repositorios.Interfaces.Produto;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Produto
{
    public class ProdutoDepartamentoRepositorio : IProdutoDepartamentoRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public ProdutoDepartamentoRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<ProdutoDepartamentoModel>> BuscarTodos()
        {
            return await _dbContext.ProdutoDepartamento.ToListAsync();
        }

        public async Task<List<ProdutoDepartamentoModel>> BuscarPorEmpresa(int empresaId)
        {
            return await _dbContext.ProdutoDepartamento
                .Include(x => x.Empresa)
                .Where(x => x.EmpresaId == empresaId)
                .OrderBy(x => x.ProdutoDepartamento)
                .ToListAsync();
        }

        public async Task<ProdutoDepartamentoModel> BuscarPorId(int id)
        {
            return await _dbContext.ProdutoDepartamento.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProdutoDepartamentoModel> BuscarPorNome(string nome)
        {
            return await _dbContext.ProdutoDepartamento.FirstOrDefaultAsync(x => x.ProdutoDepartamento == nome);
        }

        public async Task<ProdutoDepartamentoModel> Adicionar(ProdutoDepartamentoModel produtoDepartamento)
        {
            await _dbContext.ProdutoDepartamento.AddAsync(produtoDepartamento);
            await _dbContext.SaveChangesAsync();

            ProdutoDepartamentoModel novProdutoDepartamento = new ProdutoDepartamentoModel();
            novProdutoDepartamento = await BuscarPorId(novProdutoDepartamento.Id);

            return novProdutoDepartamento;
        }

        public async Task<ProdutoDepartamentoModel> Atualizar(ProdutoDepartamentoModel produtoDepartamento, int id)
        {
            ProdutoDepartamentoModel produtoDeptoSalvar = await BuscarPorId(id);
            if (produtoDeptoSalvar == null)
            {
                throw new Exception($"Grupo de Produto para o ID: {id} não foi encontrado no banco de dados...");
            }
            produtoDeptoSalvar.ProdutoDepartamento = produtoDepartamento.ProdutoDepartamento;

            _dbContext.ProdutoDepartamento.Update(produtoDepartamento);
            await _dbContext.SaveChangesAsync();

            ProdutoDepartamentoModel novoProdutoDepartamento = new ProdutoDepartamentoModel();
            novoProdutoDepartamento = await BuscarPorId(novoProdutoDepartamento.Id);

            return novoProdutoDepartamento;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoDepartamentoModel produtoDepartamentoPorId = await BuscarPorId(id);
            if (produtoDepartamentoPorId == null)
            {
                throw new Exception($"Departamento de Produto para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.ProdutoDepartamento.Remove(produtoDepartamentoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
