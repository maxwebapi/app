using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Generico
{
    public class SituacaoModel
    {
        [Comment("ID")]
        public int Id { get; set; }

        [Comment("Situação")]
        public string? Situacao { get; set; }
    }
}
