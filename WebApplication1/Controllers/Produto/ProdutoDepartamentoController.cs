using MaxWebApi.Models.Produto;
using MaxWebApi.Repositorios.Interfaces.Produto;
using MaxWebApi.Repositorios.Produto;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoDepartamentoController : ControllerBase
    {

        private readonly IProdutoDepartamentoRepositorio _produtoDepartamentoRepositorio;

        public ProdutoDepartamentoController(IProdutoDepartamentoRepositorio produtoDepartamentoRepositorio)
        {
            _produtoDepartamentoRepositorio = produtoDepartamentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoDepartamentoModel>>> BuscarTodos()
        {
            List<ProdutoDepartamentoModel> produtoDepartamentoRepositorio = await _produtoDepartamentoRepositorio.BuscarTodos();

            return Ok(produtoDepartamentoRepositorio);
        }

        [HttpGet("ProdutoDepartamentoPorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<ProdutoDepartamentoModel>>> BuscarPorEmpresa(int empresaId)
        {
            List<ProdutoDepartamentoModel> produtoDepartamento = await _produtoDepartamentoRepositorio.BuscarPorEmpresa(empresaId);

            return Ok(produtoDepartamento);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoDepartamentoModel>>> BsucarPorId(int id)
        {
            ProdutoDepartamentoModel produtoDapartamento = await _produtoDepartamentoRepositorio.BuscarPorId(id);

            return Ok(produtoDapartamento);
        }

        [HttpGet("buscarPorNome/{nome}")]
        public async Task<ActionResult<List<ProdutoDepartamentoModel>>> BuscarPorNome(string nome)
        {
            ProdutoDepartamentoModel produtoDapartamento = await _produtoDepartamentoRepositorio.BuscarPorNome(nome);

            return Ok(produtoDapartamento);
        }


        [HttpPost]
        public async Task<ActionResult<List<ProdutoDepartamentoModel>>> Cadastrar([FromBody] ProdutoDepartamentoModel produtoDapartamento)
        {
            await _produtoDepartamentoRepositorio.Adicionar(produtoDapartamento);

            return Ok(produtoDapartamento);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProdutoDepartamentoModel>>> Atualizar([FromBody] ProdutoDepartamentoModel produtoDapartamento, int id)
        {
            produtoDapartamento.Id = id;
            await _produtoDepartamentoRepositorio.Atualizar(produtoDapartamento, id);

            return Ok(produtoDapartamento);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoGrupoModel>> Apagar(int id)
        {
            bool apagado = await _produtoDepartamentoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
