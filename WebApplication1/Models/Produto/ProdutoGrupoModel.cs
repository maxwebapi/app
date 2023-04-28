using MaxWebApi.Models.Empresa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Produto
{
    public class ProdutoGrupoModel
    {
        [Comment("ID")]
        public int Id { get; set; }


        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }


        [Comment("Grupo de produto")]
        public string? ProdutoGrupo { get; set; }
    }
}
