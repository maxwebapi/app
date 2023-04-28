using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Generico
{
    public class CidadeMap : IEntityTypeConfiguration<CidadeModel>
    {
        public void Configure(EntityTypeBuilder<CidadeModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Uf).HasMaxLength(2).IsRequired();
        }
    }
}
