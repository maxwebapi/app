using MaxWebApi.Models.Empresa;
using MaxWebApi.Repositorios.Interfaces.Empresa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresaController(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmpresaModel>>> BuscarTodos()
        {
            List<EmpresaModel> empresas = await _empresaRepositorio.BuscarTodas();

            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaModel>> BsucarPorId(int id)
        {
            EmpresaModel empresas = await _empresaRepositorio.BuscarPorId(id);

            return Ok(empresas);
        }

        [HttpGet("buscarPorNome/{nome}")]
        public async Task<ActionResult<EmpresaModel>> BuscarPorNome(string nome)
        {
            EmpresaModel empresas = await _empresaRepositorio.BuscarPorNome(nome);

            return Ok(empresas);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaModel>> Cadastrar([FromBody] EmpresaModel empresa)
        {
            await _empresaRepositorio.Adicionar(empresa);

            return Ok(empresa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpresaModel>> Atualizar([FromBody] EmpresaModel empresa, int id)
        {
            empresa.Id = id;
            await _empresaRepositorio.Atualizar(empresa, id);

            return Ok(empresa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpresaModel>> Apagar(int id)
        {
            bool apagado = await _empresaRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
