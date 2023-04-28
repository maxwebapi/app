using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Repositorios.Interfaces.Generico;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Controllers.Cidade
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {

        private readonly ICidadeRepositorio _cidadeRepositorio;

        public CidadeController(ICidadeRepositorio cidadeRepositorio)
        {
            _cidadeRepositorio = cidadeRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CidadeModel>>> BuscarTodas()
        {
            List<CidadeModel> cidade = await _cidadeRepositorio.BuscarTodas();

            return Ok(cidade);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeModel>> BsucarPorId(int id)
        {
            CidadeModel cidade = await _cidadeRepositorio.BuscarPorId(id);

            return Ok(cidade);
        }

        [HttpGet("buscarPorNome/{nome}")]
        public async Task<ActionResult<CidadeModel>> BuscarPorNome(string nome)
        {
            CidadeModel cidade = await _cidadeRepositorio.BuscarPorNome(nome);

            return Ok(cidade);
        }
    }
}
