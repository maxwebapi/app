using MaxWebApi.Models.Generico;
using MaxWebApi.Repositorios.Interfaces.Generico;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Situacao
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoController : ControllerBase
    {

        private readonly ISituacaoRepositorio _situacaoRepositorio;

        public SituacaoController(ISituacaoRepositorio situacaoRepositorio)
        {
            _situacaoRepositorio = situacaoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<SituacaoModel>>> BuscarTodas()
        {
            List<SituacaoModel> situacao = await _situacaoRepositorio.BuscarTodas();

            return Ok(situacao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SituacaoModel>> BsucarPorId(int id)
        {
            SituacaoModel situacao = await _situacaoRepositorio.BuscarPorId(id);

            return Ok(situacao);
        }        
    }
}
