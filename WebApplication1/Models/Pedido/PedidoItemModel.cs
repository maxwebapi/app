
using MaxWebApi.Models.Pedido;
using MaxWebApi.Models.Produto;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.PedidoItem
{
    public class PedidoItemModel
    {
        [Comment("ID do pedido item")]
        public int Id { get; set; }


        [Comment("ID do pedido")]
        public Guid? PedidoId { get; set; }
        public virtual PedidoModel? Pedido { get; set; }


        [Comment("ID do produto")]
        public Guid? ProdutoId { get; set; }
        public virtual ProdutoModel? Produto { get; set; }


        [Comment("Quantidade")]
        public double Quantidade { get; set; }

        [Comment("Preço de venda")]
        public double PrecoVenda { get; set; }

        [Comment("Perço unitario")]
        public double PrecoUnitario { get; set; }

        [Comment("Total do Item")]
        public double TotalProdutoItem { get; set; }
    }
}
