using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Pedido
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet()]
        public async Task<ActionResult<List<PedidoModel>>> BuscarTodos()
        {
            List<PedidoModel> pedidos = await _pedidoRepositorio.BuscarTodos();

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PedidoModel>>> BsucarPorId(Guid id)
        {
            PedidoModel pedido = await _pedidoRepositorio.BuscarPorId(id);

            return Ok(pedido);
        }


        [HttpGet("PedidoPorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<PedidoModel>>> BuscarPorEmpresa(int empresaId)
        {
            List<PedidoModel> pedidos = await _pedidoRepositorio.BuscarPorEmpresa(empresaId);

            return Ok(pedidos);
        }

        [HttpGet("PedidoPorEmpresaUnidade/{empresaId}/{empresaUnidadeId}")]
        public async Task<ActionResult<List<PedidoModel>>> BuscarPorEmpresaUnicade(int empresaId, int empresaUnidadeId)
        {
            List<PedidoModel> pedidos = await _pedidoRepositorio.BuscarPorEmpresaUnicade(empresaId, empresaUnidadeId);

            return Ok(pedidos);
        }

        [HttpGet("UltimoPedido/{empresaId}/{empresaUnidadeId}")]
        public async Task<ActionResult<List<PedidoModel>>> BuscarUltimoPedido(string usuarioId)
        {
            PedidoModel pedido = await _pedidoRepositorio.BuscarUltimoPedido(usuarioId);

            return Ok(pedido);
        }


        [HttpPost]
        public async Task<ActionResult<List<PedidoModel>>> Cadastrar([FromBody] PedidoModel pedido)
        {
            await _pedidoRepositorio.Adicionar(pedido);

            return Ok(pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<PedidoModel>>> Atualizar([FromBody] PedidoModel pedido, Guid id)
        {
            pedido.Id = id;
            await _pedidoRepositorio.Atualizar(pedido, id);

            return Ok(pedido);
        }

        [HttpPut("EncerrarPedido/{id}")]
        public async Task<ActionResult<List<PedidoModel>>> EncerrarPedido([FromBody] PedidoModel pedido, Guid id)
        {
            pedido.Id = id;
            await _pedidoRepositorio.EncerrarPedido(pedido, id);

            return Ok(pedido);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoModel>> Apagar(Guid id)
        {
            bool apagado = await _pedidoRepositorio.Apagar(id);

            return Ok(apagado);
        }

    }
}
