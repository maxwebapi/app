using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using MaxWebApi.Repositorios.Pessoa;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Pessoa
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaTipoController : ControllerBase
    {

        private readonly IPessoaTipoRepositorio _pessoaTipoRepositorio;

        public PessoaTipoController(IPessoaTipoRepositorio pessoaTipoRepositorio)
        {
            _pessoaTipoRepositorio = pessoaTipoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaTipoModel>>> BuscarTodas()
        {
            List<PessoaTipoModel> pessoaTipo = await _pessoaTipoRepositorio.BuscarTodos();

            return Ok(pessoaTipo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PessoaTipoModel>>> BsucarPorId(int id)
        {
            PessoaTipoModel pessoaTipo = await _pessoaTipoRepositorio.BuscarPorId(id);

            return Ok(pessoaTipo);
        }
    }
}
