using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios;
using MaxWebApi.Repositorios.Interfaces.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Pessoa
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaContribuinteController : ControllerBase
    {

        private readonly IPessoaContribuinteRepositorio _pessoaContribuinteRepositorio;

        public PessoaContribuinteController(IPessoaContribuinteRepositorio pessoaContribuinteRepositorio)
        {
            _pessoaContribuinteRepositorio = pessoaContribuinteRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaContribuinteModel>>> BuscarTodas()
        {
            List<PessoaContribuinteModel> pessoaContribuinte = await _pessoaContribuinteRepositorio.BuscarTodos();

            return Ok(pessoaContribuinte);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PessoaContribuinteModel>>> BsucarPorId(int id)
        {
            PessoaContribuinteModel pessoaContribuinte = await _pessoaContribuinteRepositorio.BuscarPorId(id);

            return Ok(pessoaContribuinte);
        }
    }
}
