using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Generico;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Produto
{
    public class ProdutoModel
    {
        [Comment("ID")]
        public Guid Id { get; set; }


        [Comment("Nome do produto")]
        public string? Nome { get; set; }

        [Comment("Complemento")]
        public string? Complemento { get; set; }

        [Comment("Id do Produto por Empresa")]
        public int? ProdutoId { get; set; }


        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }


        [Comment("ID da situação")]
        public int? SituacaoId { get; set; }
        public virtual SituacaoModel? Situacao { get; set; }


        [Comment("ID do grupo")]
        public int? ProdutoGrupoId { get; set; }
        public virtual ProdutoGrupoModel? ProdutoGrupo { get; set; }

        [Comment("ID do departamento")]
        public int? ProdutoDepartamentoId { get; set; }
        public virtual ProdutoDepartamentoModel? ProdutoDepartamento { get; set; }

        [Comment("ID do NCM")]
        public int? NcmId { get; set; }
        public virtual NcmModel? Ncm { get; set; }

        [Comment("CEST")]
        public string? Cest { get; set; }

        [Comment("EAN (código de barras)")]
        public string? Ean { get; set; }

        [Comment("Referência")]
        public string? Referencia { get; set; }

        [Comment("Código do fabricante")]
        public string? CodigoFabricante { get; set; }


        [Comment("Preço de Custo")]
        public double? PrecoCusto { get; set; }

        [Comment("Margem de Lucro")]
        public double? MargemLucro { get; set; }

        [Comment("Preço de Venda")]
        public double? PrecoVenda { get; set; }

        [Comment("Peso Líquido")]
        public double? PesoLiquido { get; set; }

        [Comment("Peso Bruto")]
        public double? PesoBruto { get; set; }

        [Comment("Estoque Mínimo")]
        public double? EstoqueMinimo { get; set; }

        [Comment("Estoque Máximo")]
        public double? EstoqueMaximo { get; set; }
    }
}
