using MaxWebApi.Models.Empresa;
using MaxWebApi.Repositorios.Interfaces.Empresa;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaUnidadeController : ControllerBase
    {

        private readonly IEmpresaUnidadeRepositorio _empresaUnidadeRepositorio;

        public EmpresaUnidadeController(IEmpresaUnidadeRepositorio empresaUnidadeRepositorio)
        {
            _empresaUnidadeRepositorio = empresaUnidadeRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpresaUnidadeModel>>> BuscarTodas()
        {
            List<EmpresaUnidadeModel> empresaUnidade = await _empresaUnidadeRepositorio.BuscarTodas();

            return Ok(empresaUnidade);
        }

        [HttpGet("UnidadePorEmpresa/{empresaId}")]
        public async Task<ActionResult<EmpresaUnidadeModel>> BuscarUnidadePorEmpresa(int empresaId)
        {
            List<EmpresaUnidadeModel> empresaUnidade = await _empresaUnidadeRepositorio.BuscarUnidadePorEmpresa(empresaId);

            return Ok(empresaUnidade);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaUnidadeModel>> BuscarPorId(int id)
        {
            EmpresaUnidadeModel empresaUnidade = await _empresaUnidadeRepositorio.BuscarPorId(id);

            return Ok(empresaUnidade);
        }

        [HttpGet("buscarPorNome/{nome}")]
        public async Task<ActionResult<EmpresaUnidadeModel>> BuscarPorNome(string nome)
        {
            EmpresaUnidadeModel empresaUnidade = await _empresaUnidadeRepositorio.BuscarPorNome(nome);

            return Ok(empresaUnidade);
        }

        [HttpPost]
        public async Task<ActionResult<List<EmpresaUnidadeModel>>> Cadastrar([FromBody] EmpresaUnidadeModel empresaUnidade)
        {
            await _empresaUnidadeRepositorio.Adicionar(empresaUnidade);

            return Ok(empresaUnidade);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<EmpresaUnidadeModel>>> Atualizar([FromBody] EmpresaUnidadeModel empresaUnidade, int id)
        {
            empresaUnidade.Id = id;
            await _empresaUnidadeRepositorio.Atualizar(empresaUnidade, id);

            return Ok(empresaUnidade);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpresaUnidadeModel>> Apagar(int id)
        {
            bool apagado = await _empresaUnidadeRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
