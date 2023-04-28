using MaxWebApi.Models.Pedido;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.Pedido
{
    public class PedidoMap : IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PedidoId).IsRequired();

            builder.Property(x => x.EmpresaId).IsRequired();
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.EmpresaUnidadeId).IsRequired();
            builder.HasOne(x => x.EmpresaUnidade);

            builder.Property(x => x.PessoaId).IsRequired();
            builder.HasOne(x => x.Pessoa);

            builder.Property(x => x.SituacaoId).IsRequired();
            builder.HasOne(x => x.Situacao);

            builder.Property(x => x.VendedorId);
            builder.Property(x => x.UsuarioId);

            builder.Property(x => x.DataCadastro).IsRequired();
            builder.Property(x => x.TotalProduto).IsRequired();
            builder.Property(x => x.TotalDesconto).IsRequired();
            builder.Property(x => x.PercDesconto).IsRequired();
            builder.Property(x => x.TotalLiquido).IsRequired();
            builder.Property(x => x.Importado).IsRequired().HasDefaultValue('N');
        }
    }
}
