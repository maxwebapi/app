using MaxWebApi.Models.Produto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Produto
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Complemento).HasMaxLength(100);

            builder.Property(x => x.ProdutoId).IsRequired();

            builder.Property(x => x.EmpresaId).IsRequired();
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.SituacaoId).IsRequired();
            builder.HasOne(x => x.Situacao);

            builder.Property(x => x.ProdutoGrupoId).IsRequired();
            builder.HasOne(x => x.ProdutoGrupo);

            builder.Property(x => x.ProdutoDepartamentoId).IsRequired();
            builder.HasOne(x => x.ProdutoDepartamento);

            builder.Property(x => x.NcmId).IsRequired();
            builder.HasOne(x => x.Ncm);

            builder.Property(x => x.Cest).HasMaxLength(7);

            builder.Property(x => x.Ean).HasMaxLength(13);

            builder.Property(x => x.Referencia).HasMaxLength(50);

            builder.Property(x => x.CodigoFabricante).HasMaxLength(50);

            builder.Property(x => x.PrecoCusto).IsRequired();
            builder.Property(x => x.MargemLucro).IsRequired();
            builder.Property(x => x.PrecoVenda).IsRequired();

            builder.Property(x => x.PesoLiquido);
            builder.Property(x => x.PesoBruto);
            builder.Property(x => x.EstoqueMinimo);
            builder.Property(x => x.EstoqueMaximo);
        }
    }
}