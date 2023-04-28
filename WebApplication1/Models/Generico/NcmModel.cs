using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Generico
{
    public class NcmModel
    {
        [Comment("ID")]
        public int Id { get; set; }

        [Comment("Cest")]
        public string? Cest { get; set; }

        [Comment("Descrição")]
        public string? Descricao { get; set; }
    }
}
