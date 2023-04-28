using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.PedidoItem;
using MaxWebApi.Repositorios.Interfaces.PedidoItem;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.PedidoItem
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItemController : ControllerBase
    {
        private readonly IPedidoItemRepositorio _pedidoItemRepositorio;

        public PedidoItemController(IPedidoItemRepositorio pedidoItemRepositorio)
        {
            _pedidoItemRepositorio = pedidoItemRepositorio;
        }

        [HttpGet("PedidoItemPorPedido/{pedidoId}")]
        public async Task<ActionResult<List<PedidoItemModel>>> BuscarPorPedido(Guid pedidoId)
        {
            List<PedidoItemModel> pedidoItem = await _pedidoItemRepositorio.BuscarPorPedido(pedidoId);

            return Ok(pedidoItem);
        }

        [HttpPost]
        public async Task<ActionResult<List<PedidoItemModel>>> Cadastrar([FromBody] PedidoItemModel pedidoItem)
        {
            await _pedidoItemRepositorio.Adicionar(pedidoItem);

            return Ok(pedidoItem);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoItemModel>> Apagar(int id)
        {
            bool apagado = await _pedidoItemRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
