using MaxWebApi.Models.Empresa;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MaxWebApi.Data.Map.Empresa
{
    public class EmpresaUnidadeMap : IEntityTypeConfiguration<EmpresaUnidadeModel>
    {
        public void Configure(EntityTypeBuilder<EmpresaUnidadeModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);

            builder.Property(x => x.EmpresaId);
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.CidadeId).IsRequired();
            builder.HasOne(x => x.Cidade);

            builder.Property(x => x.Cep).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Complemento).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Cnpj).HasMaxLength(20);
            builder.Property(x => x.Ie).HasMaxLength(20);
        }
    }
}
