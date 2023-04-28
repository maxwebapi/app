using MaxWebApi.Models.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Produto
{
    public class ProdutoDepartamentoMap : IEntityTypeConfiguration<ProdutoDepartamentoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoDepartamentoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmpresaId).IsRequired();
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.ProdutoDepartamento).IsRequired().HasMaxLength(100);
        }
    }
}