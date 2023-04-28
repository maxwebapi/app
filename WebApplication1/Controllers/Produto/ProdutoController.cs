using MaxWebApi.Models.Pessoa;
using MaxWebApi.Models.Produto;
using MaxWebApi.Repositorios.Interfaces.Produto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MaxWebApi.Controllers.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodos()
        {
            List<ProdutoModel> produto = await _produtoRepositorio.BuscarTodos();

            return Ok(produto);
        }

        [HttpGet("ProdutoPorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarPorEmpresa(int empresaId)
        {
            List<ProdutoModel> produto = await _produtoRepositorio.BuscarPorEmpresa(empresaId);

            return Ok(produto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProdutoModel>>> BsucarPorId(Guid id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);

            return Ok(produto);
        }

        [HttpGet("buscarPorNome/{nome}")]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarPorNome(string nome)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorNome(nome);

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProdutoModel>>> Cadastrar([FromBody] ProdutoModel produto)
        {
            await _produtoRepositorio.Adicionar(produto);

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProdutoModel>>> Atualizar([FromBody] ProdutoModel produto, Guid id)
        {
            produto.Id = id;
            await _produtoRepositorio.Atualizar(produto, id);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(Guid id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
