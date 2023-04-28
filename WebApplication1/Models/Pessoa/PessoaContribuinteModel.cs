using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Pessoa
{
    public class PessoaContribuinteModel
    {
        [Comment("ID")]
        public int Id { get; set; }

        [Comment("Descrição")]
        public string? Descricao { get; set; }
    }
}
