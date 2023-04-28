using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Pedido
{
    public class PedidoModel
    {
        [Comment("ID do pedido")]
        public Guid Id { get; set; }


        [Comment("ID sequencia do pedido por empresa")]
        public int PedidoId { get; set; }


        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }


        [Comment("ID da empresa unidade")]
        public int? EmpresaUnidadeId { get; set; }
        public virtual EmpresaUnidadeModel? EmpresaUnidade { get; set; }


        [Comment("ID do cliente")]
        public Guid? PessoaId { get; set; }
        public virtual PessoaModel? Pessoa { get; set; }


        [Comment("ID do vendedor")]
        public Guid? VendedorId { get; set; }

        [Comment("ID do usuário")]
        public Guid? UsuarioId { get; set; }


        [Comment("ID da sutuacao")]
        public int? SituacaoId { get; set; }
        public virtual SituacaoModel? Situacao { get; set; }


        [Comment("Dada de cadastro")]
        public DateTime DataCadastro { get; set; }


        [Comment("Total de Produto")]
        public double TotalProduto { get; set; }


        [Comment("Total de Desconto")]
        public double TotalDesconto { get; set; }


        [Comment("Percentual de Desconto")]
        public double PercDesconto { get; set; }

        [Comment("Total Liquido")]
        public double TotalLiquido { get; set; }

        [Comment("Importado")]
        public string Importado { get; set; }

    }
}
