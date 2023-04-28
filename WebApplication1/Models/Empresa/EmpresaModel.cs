using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Empresa
{
    public class EmpresaModel
    {
        [Comment("ID")]
        public int Id { get; set; }

        [Comment("Nome")]
        public string? Nome { get; set; }

        [Comment("ID de situação")]
        public int? SituacaoId { get; set; }
        public virtual SituacaoModel? Situacao { get; set; }

        




    }
}
