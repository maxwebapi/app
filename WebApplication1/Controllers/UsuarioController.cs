using MaxWebApi.Models;
using MaxWebApi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Models.UsuarioModel>>> BuscarTodos()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodos();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BsucarPorId(Guid id)
        {
            UsuarioModel usuarios = await _usuarioRepositorio.BuscarPorId(id);

            return Ok(usuarios);
        }

        [HttpGet("buscarPorEmail/{email}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorEmail(string email)
        {
            UsuarioModel usuarios = await _usuarioRepositorio.BuscarPorEmail(email);

            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> Cadastrar([FromBody] UsuarioModel usuario)
        {
            await _usuarioRepositorio.Adicionar(usuario);

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> Atualizar([FromBody] UsuarioModel usuario, Guid id)
        {
            usuario.Id = id;
            await _usuarioRepositorio.Atualizar(usuario, id);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(Guid id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
