using MaxWebApi.Models.Produto;
using MaxWebApi.Repositorios.Interfaces.Produto;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoGrupoController : ControllerBase
    {

        private readonly IProdutoGrupoRepositorio _produtoGrupoRepositorio;

        public ProdutoGrupoController(IProdutoGrupoRepositorio produtoGrupoRepositorio)
        {
            _produtoGrupoRepositorio = produtoGrupoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoGrupoModel>>> BuscarTodos()
        {
            List<ProdutoGrupoModel> produtoGrupo = await _produtoGrupoRepositorio.BuscarTodos();

            return Ok(produtoGrupo);
        }

        [HttpGet("ProdutoGrupoPorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<ProdutoGrupoModel>>> BuscarPorEmpresa(int empresaId)
        {
            List<ProdutoGrupoModel> produtoGrupo = await _produtoGrupoRepositorio.BuscarPorEmpresa(empresaId);

            return Ok(produtoGrupo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoGrupoModel>>> BsucarPorId(int id)
        {
            ProdutoGrupoModel produtoGrupo = await _produtoGrupoRepositorio.BuscarPorId(id);

            return Ok(produtoGrupo);
        }

        [HttpGet("buscarPorNome/{nome}")]
        public async Task<ActionResult<List<ProdutoGrupoModel>>> BuscarPorNome(string nome)
        {
            ProdutoGrupoModel produtoGrupo = await _produtoGrupoRepositorio.BuscarPorNome(nome);

            return Ok(produtoGrupo);
        }


        [HttpPost]
        public async Task<ActionResult<List<ProdutoGrupoModel>>> Cadastrar([FromBody] ProdutoGrupoModel produtoGrupo)
        {
            await _produtoGrupoRepositorio.Adicionar(produtoGrupo);

            return Ok(produtoGrupo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProdutoGrupoModel>>> Atualizar([FromBody] ProdutoGrupoModel produtoGrupo, int id)
        {
            produtoGrupo.Id = id;
            await _produtoGrupoRepositorio.Atualizar(produtoGrupo, id);

            return Ok(produtoGrupo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoGrupoModel>> Apagar(int id)
        {
            bool apagado = await _produtoGrupoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
