using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models
{
    public class UsuarioModel
    {
        [Comment("ID")]
        public Guid Id { get; set; }

        [Comment("Email")]
        public string? Email { get; set; }

        [Comment("Senha")]
        public string? Senha { get; set; }

        [Comment("ID da pessoa")]
        public Guid? PessoaId { get; set; }
        public virtual PessoaModel? Pessoa { get; set; }


        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }

        [Comment("ID da situacao")]
        public int? SituacaoId { get; set; }
        public virtual SituacaoModel? Situacao { get; set; }


    }
}
