using MaxWebApi.Models.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Produto
{
    public class ProdutoGrupoMap : IEntityTypeConfiguration<ProdutoGrupoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoGrupoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EmpresaId).IsRequired();
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.ProdutoGrupo).IsRequired().HasMaxLength(100);
        }
    }
}