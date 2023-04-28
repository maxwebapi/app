using AppApi.Data;
using MaxWebApi.Models;
using MaxWebApi.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly MaxWebApiDBContext _dbContext;
        public UsuarioRepositorio(MaxWebApiDBContext maxWebApiDBContext)
        {
            _dbContext = maxWebApiDBContext;   
        }

        public async Task<List<UsuarioModel>> BuscarTodos()
        {
            return await _dbContext.Usuario
                .Include(x => x.Pessoa)
                .Include(x => x.Pessoa.PessoaContribuinte)
                .Include(x => x.Pessoa.PessoaTipo)
                .Include(x => x.Empresa)
                .Include(x => x.Situacao)
                .ToListAsync();
        }

        public async Task<UsuarioModel> BuscarPorId(Guid id)
        {
            return await _dbContext.Usuario
                .Include(x => x.Pessoa)
                .Include(x => x.Pessoa.PessoaContribuinte)
                .Include(x => x.Pessoa.PessoaTipo)
                .Include(x => x.Empresa)
                .Include(x => x.Situacao)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UsuarioModel> BuscarPorEmail(string email)
        {
            return await _dbContext.Usuario
                .Include(x => x.Pessoa)
                .Include(x => x.Pessoa.PessoaContribuinte)
                .Include(x => x.Pessoa.PessoaTipo)
                .Include(x => x.Empresa)
                .Include(x => x.Situacao)
                .FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            UsuarioModel novoUsuario = new UsuarioModel();
            novoUsuario = await BuscarPorId(usuario.Id);

            return novoUsuario;
        }
        
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, Guid id)
        {
            UsuarioModel usuarioSalvar = await BuscarPorId(id);
            if (usuarioSalvar == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados...");
            }
            usuarioSalvar.Email = usuario.Email;
            usuarioSalvar.Senha = usuario.Senha;
            usuarioSalvar.PessoaId = usuario.PessoaId;
            usuarioSalvar.EmpresaId = usuario.EmpresaId;
            usuarioSalvar.SituacaoId = usuario.SituacaoId;

            _dbContext.Usuario.Update(usuarioSalvar);    
            await _dbContext.SaveChangesAsync();

            UsuarioModel novoUsuario = new UsuarioModel();
            novoUsuario = await BuscarPorId(usuarioSalvar.Id);

            return novoUsuario;
        }

        public async Task<bool> Apagar(Guid id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados...");
            }
            _dbContext.Usuario.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;    
        }
    }
}
