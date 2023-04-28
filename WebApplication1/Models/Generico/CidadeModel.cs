using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Generico
{
    public class CidadeModel
    {
        [Comment("ID")]
        public int Id { get; set; }

        [Comment("Nome completo")]
        public string? Nome { get; set; }

        [Comment("UF unidade federativa")]
        public string? Uf { get; set; }
    }
}
