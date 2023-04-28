using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Generico;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Models.Pessoa
{
    public class PessoaModel
    {
        [Comment("ID da pessoa")]
        public Guid Id { get; set; }


        [Comment("ID sequencia de pessoa por empresa")]
        public int PessoaId { get; set; }


        [Comment("Nome da pessoa")]
        public string? Nome { get; set; }


        [Comment("ID da empresa")]
        public int? EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; }


        [Comment("ID do tipo de pessoa")]
        public int? PessoaTipoId { get; set; }
        public virtual PessoaTipoModel? PessoaTipo { get; set; }


        [Comment("ID do tipo de contribuinte")]
        public int? PessoaContribuinteId { get; set; }
        public virtual PessoaContribuinteModel? PessoaContribuinte { get; set; }


        [Comment("ID da situação")]
        public int? SituacaoId { get; set; }
        public virtual SituacaoModel? Situacao { get; set; }


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


        [Comment("CPF")]
        public string? Cpf { get; set; }

        
        [Comment("RG documento de identidade")]
        public string? Rg { get; set; }

        
        [Comment("CNPJ")]
        public string? Cnpj { get; set; }


        [Comment("IE inscrição estadual")]
        public string? Ie { get; set; }


        [Comment("Telefone comercial")]
        public string? TelComercial { get; set; }

        [Comment("Telefone para contato")]
        public string? TelContato { get; set; }

        [Comment("Telefone celular")]
        public string? TelCelular { get; set; }

        [Comment("Cliente")]
        public string? Cliente { get; set; }

        [Comment("Vendedor")]
        public string? Vendedor { get; set; }

        [Comment("Data de cadastro")]
        public DateTime? DataCadastro { get; set; }


    }
}
