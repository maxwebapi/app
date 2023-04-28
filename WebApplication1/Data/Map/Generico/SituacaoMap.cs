using MaxWebApi.Models.Generico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Generico
{
    public class SituacaoMap : IEntityTypeConfiguration<SituacaoModel>
    {
        public void Configure(EntityTypeBuilder<SituacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Situacao).IsRequired().HasMaxLength(100);
        }
    }
}
