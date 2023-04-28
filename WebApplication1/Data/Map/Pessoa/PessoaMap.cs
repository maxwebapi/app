using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MaxWebApi.Models.Pessoa;

namespace MaxWebApi.Data.Map.Pessoa
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PessoaId).IsRequired();

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);

            builder.Property(x => x.PessoaTipoId).IsRequired();
            builder.HasOne(x => x.PessoaTipo);

            builder.Property(x => x.PessoaContribuinteId).IsRequired();
            builder.HasOne(x => x.PessoaContribuinte);

            builder.Property(x => x.SituacaoId).IsRequired();
            builder.HasOne(x => x.Situacao);

            builder.Property(x => x.EmpresaId).IsRequired();
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.CidadeId).IsRequired();
            builder.HasOne(x => x.Cidade);

            builder.Property(x => x.Cep).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Complemento).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Cpf).HasMaxLength(14);
            builder.Property(x => x.Rg).HasMaxLength(20);
            builder.Property(x => x.Cnpj).HasMaxLength(20);
            builder.Property(x => x.Ie).HasMaxLength(20);
            builder.Property(x => x.TelComercial).HasMaxLength(20);
            builder.Property(x => x.TelContato).HasMaxLength(20);
            builder.Property(x => x.TelCelular).HasMaxLength(20);
            builder.Property(x => x.Cliente).HasMaxLength(1);
            builder.Property(x => x.Vendedor).HasMaxLength(1);
            builder.Property(x => x.DataCadastro);

        }
    }
}
