using AppApi.Data;
using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Pedido;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios.Pedido
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public PedidoRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;
        }

        public async Task<List<PedidoModel>> BuscarTodos()
        {
            return await _dbContext.Pedido
                .Include(x => x.Empresa)
                .Include(x => x.EmpresaUnidade)
                .Include(x => x.Pessoa)
                .Include(x => x.Pessoa.PessoaTipo)
                .Include(x => x.Situacao)
                .ToListAsync();
        }

        public async Task<List<PedidoModel>> BuscarPorEmpresa(int empresaId)
        {
            return await _dbContext.Pedido
                .Include(x => x.Empresa)
                .Include(x => x.EmpresaUnidade)
                .Include(x => x.Pessoa)
                .Include(x => x.Situacao)
                .Where(x => x.EmpresaId == empresaId)
                .ToListAsync();
        }

        public async Task<List<PedidoModel>> BuscarPorEmpresaUnicade(int empresaId, int empresaUnidadeId)
        {
            return await _dbContext.Pedido
                .Include(x => x.Empresa)
                .Include(x => x.EmpresaUnidade)
                .Include(x => x.Pessoa)
                .Include(x => x.Situacao)
                .Where(x => x.EmpresaId.Equals(empresaId) && x.EmpresaUnidadeId.Equals(empresaUnidadeId))
                .ToListAsync();
        }

        public async Task<PedidoModel> BuscarUltimoPedido(string usuarioId)
        {
            return await _dbContext.Pedido
                .OrderByDescending(x => x.PedidoId)
                .FirstOrDefaultAsync(x => x.UsuarioId.Equals(usuarioId));
        }

        public async Task<PedidoModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Pedido
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PedidoModel> Adicionar(PedidoModel pedido)
        {
            await _dbContext.Pedido.AddAsync(pedido);
            await _dbContext.SaveChangesAsync();

            PedidoModel novoPedido = new PedidoModel();
            novoPedido = await BuscarPorId(pedido.Id);

            return novoPedido;
        }

        public async Task<PedidoModel> Atualizar(PedidoModel pedido, Guid id)
        {
            PedidoModel pedidoSalvar = await BuscarPorId(id);
            if (pedidoSalvar == null)
            {
                throw new Exception($"Pedido para o ID: {id} não foi encontrado no banco de dados...");
            }
            pedidoSalvar.EmpresaId = pedido.EmpresaId;

            _dbContext.Pedido.Update(pedidoSalvar);
            await _dbContext.SaveChangesAsync();

            PedidoModel novoPedido = new PedidoModel();
            novoPedido = await BuscarPorId(pedido.Id);

            return novoPedido;
        }

        public async Task<PedidoModel> EncerrarPedido(PedidoModel pedido, Guid id)
        {
            PedidoModel pedidoEncerrar = await BuscarPorId(id);
            if (pedidoEncerrar == null)
            {
                throw new Exception($"Pedido para o ID: {id} não foi encontrado no banco de dados...");
            }

            _dbContext.Pedido.Update(pedidoEncerrar);
            await _dbContext.SaveChangesAsync();

            PedidoModel novoPedido = new PedidoModel();
            novoPedido = await BuscarPorId(pedido.Id);

            return novoPedido;
        }


        public async Task<bool> Apagar(Guid id)
        {
            PedidoModel pedidoPorId = await BuscarPorId(id);
            if (pedidoPorId == null)
            {
                throw new Exception($"Pedido para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.Pedido.Remove(pedidoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
