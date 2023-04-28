using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Pessoa
{
    public class PessoaTipoModel
    {
        [Comment("ID")]
        public int Id { get; set; }

        [Comment("Descrição")]
        public string? Descricao { get; set; }
    }
}
