using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Data.Map.Pessoa
{
    public class PessoaContribuinteMap : IEntityTypeConfiguration<PessoaContribuinteModel>
    {
        public void Configure(EntityTypeBuilder<PessoaContribuinteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(20);
        }
    }
}
