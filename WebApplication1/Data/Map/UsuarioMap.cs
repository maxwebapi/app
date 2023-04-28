using MaxWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaxWebApi.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(100);

            builder.Property(x => x.PessoaId).IsRequired();
            builder.HasOne(x => x.Pessoa);

            builder.Property(x => x.EmpresaId).IsRequired();
            builder.HasOne(x => x.Empresa);

            builder.Property(x => x.SituacaoId).IsRequired();
            builder.HasOne(x => x.Situacao);

        }
    }
}
