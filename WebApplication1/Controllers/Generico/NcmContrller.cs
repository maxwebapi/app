using MaxWebApi.Models.Generico;
using MaxWebApi.Repositorios.Interfaces.Generico;
using Microsoft.AspNetCore.Mvc;

namespace MaxWebApi.Controllers.Ncm
{
    [Route("api/[controller]")]
    [ApiController]
    public class NcmController : ControllerBase
    {

        private readonly INcmRepositorio _ncmRepositorio;

        public NcmController(INcmRepositorio ncmRepositorio)
        {
            _ncmRepositorio = ncmRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<NcmModel>>> BuscarTodos()
        {
            List<NcmModel> ncm = await _ncmRepositorio.BuscarTodos();

            return Ok(ncm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NcmModel>> BsucarPorId(int id)
        {
            NcmModel ncm = await _ncmRepositorio.BuscarPorId(id);

            return Ok(ncm);
        }

        [HttpGet("buscarPorNome/{descricao}")]
        public async Task<ActionResult<NcmModel>> BuscarPorNome(string descricao)
        {
            NcmModel ncm = await _ncmRepositorio.BuscarPorDescricao(descricao);

            return Ok(ncm);
        }
    }
}
