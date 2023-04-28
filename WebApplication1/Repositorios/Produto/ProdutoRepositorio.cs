using AppApi.Data;
using MaxWebApi.Models;
using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Models.Produto;
using MaxWebApi.Repositorios.Interfaces.Produto;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Produto
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public ProdutoRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<ProdutoModel>> BuscarTodos()
        {
            return await _dbContext.Produto
                .Include(x => x.Empresa)
                .Include(x => x.ProdutoGrupo)
                .Include(x => x.ProdutoDepartamento)
                .Include(x => x.Situacao)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<List<ProdutoModel>> BuscarPorEmpresa(int empresaId)
        {
            return await _dbContext.Produto
                .Include(x => x.Empresa)
                .Include(x => x.ProdutoGrupo)
                .Include(x => x.ProdutoDepartamento)
                .Include(x => x.Situacao)
                .Where(x => x.EmpresaId == empresaId)
                .OrderBy(x => x.Nome)
                .ToListAsync();
        }

        public async Task<ProdutoModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Produto
                .Include(x => x.Empresa)
                .Include(x => x.ProdutoGrupo)
                .Include(x => x.ProdutoDepartamento)
                .Include(x => x.Situacao)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProdutoModel> BuscarPorNome(string nome)
        {
            return await _dbContext.Produto
                .Include(x => x.Empresa)
                .Include(x => x.ProdutoGrupo)
                .Include(x => x.ProdutoDepartamento)
                .Include(x => x.Situacao)
                .FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            ProdutoModel novoProduto = new ProdutoModel();
            novoProduto = await BuscarPorId(novoProduto.Id);

            return novoProduto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, Guid id)
        {
            ProdutoModel produtoSalvar = await BuscarPorId(id);
            if (produtoSalvar == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados...");
            }
            produtoSalvar.Nome = produto.Nome;
            produtoSalvar.Complemento = produto.Complemento;
            produtoSalvar.ProdutoGrupoId = produto.ProdutoGrupoId;
            produtoSalvar.ProdutoDepartamentoId = produto.ProdutoDepartamentoId;
            produtoSalvar.SituacaoId = produto.SituacaoId;
            produtoSalvar.NcmId = produto.NcmId;
            produtoSalvar.ProdutoId = produto.ProdutoId;
            produtoSalvar.Cest = produto.Cest;
            produtoSalvar.Ean = produto.Ean;
            produtoSalvar.Referencia = produto.Referencia;
            produtoSalvar.CodigoFabricante = produto.CodigoFabricante;
            produtoSalvar.PrecoCusto = produto.PrecoCusto;
            produtoSalvar.MargemLucro = produto.MargemLucro;
            produtoSalvar.PrecoVenda = produto.PrecoVenda;
            produtoSalvar.PesoLiquido = produto.PesoLiquido;
            produtoSalvar.PesoBruto = produto.PesoBruto;
            produtoSalvar.EstoqueMinimo = produto.EstoqueMinimo;
            produtoSalvar.EstoqueMaximo = produto.EstoqueMaximo;

            _dbContext.Produto.Update(produtoSalvar);
            await _dbContext.SaveChangesAsync();

            ProdutoModel novoProduto = new ProdutoModel();
            novoProduto = await BuscarPorId(novoProduto.Id);

            return novoProduto;
        }

        public async Task<bool> Apagar(Guid id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
