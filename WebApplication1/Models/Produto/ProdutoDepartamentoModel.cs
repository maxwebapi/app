using MaxWebApi.Models.Empresa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Produto
{
    public class ProdutoDepartamentoModel
    {
        [Comment("ID")]
        public int Id { get; set; }


        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }


        [Comment("Departamento de produto")]
        public string? ProdutoDepartamento { get; set; }
    }
}
