using MaxWebApi.Models.PedidoItem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map.PedidoItem
{
    public class PedidoItemMap : IEntityTypeConfiguration<PedidoItemModel>
    {
        public void Configure(EntityTypeBuilder<PedidoItemModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PedidoId).IsRequired();
            builder.HasOne(x => x.Pedido);

            builder.Property(x => x.ProdutoId).IsRequired();
            builder.HasOne(x => x.Produto);

            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.PrecoVenda).IsRequired();
            builder.Property(x => x.PrecoUnitario).IsRequired();
            builder.Property(x => x.TotalProdutoItem).IsRequired();
        }
    }
}


