using MaxWebApi.Models.Empresa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Empresa
{
    public class EmpresaMap : IEntityTypeConfiguration<EmpresaModel>
    {
        public void Configure(EntityTypeBuilder<EmpresaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);

            builder.Property(x => x.SituacaoId).IsRequired();
            builder.HasOne(x => x.Situacao);

        }
    }
}
