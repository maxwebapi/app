using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Empresa
{
    public class EmpresaUnidadeModel
    {
        [Comment("ID da empresa unidade")]
        public int Id { get; set; }

        [Comment("Nome da empresa unidade")]
        public string? Nome { get; set; }

        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }

        [Comment("ID da cidade")]
        public int? CidadeId { get; set; }
        public virtual CidadeModel? Cidade { get; set; }

        [Comment("Código de endereçamento posta CEP")]
        public string? Cep { get; set; }

        [Comment("Nome do bairro")]
        public string? Bairro { get; set; }

        [Comment("Endereço completo (Rua/Av/etc...")]
        public string? Endereco { get; set; }

        [Comment("Número do endereço")]
        public string? Numero { get; set; }

        [Comment("Complemento do endereço")]
        public string? Complemento { get; set; }

        [Comment("Email")]
        public string? Email { get; set; }

        [Comment("CNPJ cadastro de pessoa jurídica")]
        public string? Cnpj { get; set; }

        [Comment("IE inscrição estauda")]
        public string? Ie { get; set; }





    }
}
