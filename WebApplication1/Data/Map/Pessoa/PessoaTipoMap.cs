using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Data.Map.Pessoa
{
    public class PessoaTipoMap : IEntityTypeConfiguration<PessoaTipoModel>
    {
        public void Configure(EntityTypeBuilder<PessoaTipoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(20);
        }
    }
}
