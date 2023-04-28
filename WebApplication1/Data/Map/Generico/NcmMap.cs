using MaxWebApi.Models.Generico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Generico
{
    public class NcmMap : IEntityTypeConfiguration<NcmModel>
    {
        public void Configure(EntityTypeBuilder<NcmModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cest).IsRequired().HasMaxLength(7);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1500);
        }
    }
}
