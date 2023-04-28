using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Pessoa
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        [HttpGet()]
        public async Task<ActionResult<List<PessoaModel>>> BuscarTodas()
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarTodas();

            return Ok(pessoas);
        }

        [HttpGet("PessoaPorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarPorEmpresa(int empresaId)
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarPorEmpresa(empresaId);

            return Ok(pessoas);
        }

        [HttpGet("ClientePorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarClientePorEmpresa(int empresaId)
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarClientePorEmpresa(empresaId);

            return Ok(pessoas);
        }

        [HttpGet("VendedorPorEmpresa/{empresaId}")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarVendedorPorEmpresa(int empresaId)
        {
            List<PessoaModel> pessoas = await _pessoaRepositorio.BuscarVendedorPorEmpresa(empresaId);

            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PessoaModel>>> BsucarPorId(Guid id)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarPorId(id);

            return Ok(pessoa);
        }

        [HttpGet("pessoaPorNome/{nome}")]
        public async Task<ActionResult<List<PessoaModel>>> BuscarPorNome(string nome)
        {
            PessoaModel pessoa = await _pessoaRepositorio.BuscarPorNome(nome);

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<List<PessoaModel>>> Cadastrar([FromBody] PessoaModel pessoa)
        {
            await _pessoaRepositorio.Adicionar(pessoa);

            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<PessoaModel>>> Atualizar([FromBody] PessoaModel pessoa, Guid id)
        {
            pessoa.Id = id;
            await _pessoaRepositorio.Atualizar(pessoa, id);

            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaModel>> Apagar(Guid id)
        {
            bool apagado = await _pessoaRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
