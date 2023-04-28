using Microsoft.EntityFrameworkCore;

using MaxWebApi.Models;
using MaxWebApi.Models.Generico;
using MaxWebApi.Models.Pessoa;
using MaxWebApi.Models.Empresa;
using MaxWebApi.Models.Produto;
using MaxWebApi.Models.Pedido;

using MaxWebApi.Data.Map;
using MaxWebApi.Data.Map.Empresa;
using MaxWebApi.Data.Map.Produto;
using MaxWebApi.Data.Map.Generico;
using MaxWebApi.Data.Map.Pedido;
using MaxWebApi.Data.Map.Pessoa;
using MaxWebApi.Data.Map.PedidoItem;
using MaxWebApi.Models.PedidoItem;

namespace AppApi.Data
{
    public class MaxWebApiDBContext : DbContext
    {
        public MaxWebApiDBContext(DbContextOptions<MaxWebApiDBContext> options) 
            : base(options)
        { 

        }
        public DbSet<CidadeModel> Cidade { get; set; }
        public DbSet<SituacaoModel> Situacao { get; set; }
        public DbSet<NcmModel> Ncm { get; set; }


        public DbSet<EmpresaModel> Empresa { get; set; }
        public DbSet<EmpresaUnidadeModel> EmpresaUnidade { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }

        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<PessoaContribuinteModel> PessoaContribuinte { get; set; }
        public DbSet<PessoaTipoModel> PessoaTipo { get; set; }

        public DbSet<ProdutoGrupoModel> ProdutoGrupo { get; set; }
        public DbSet<ProdutoDepartamentoModel> ProdutoDepartamento { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }

        public DbSet<PedidoModel> Pedido { get; set; }
        public DbSet<PedidoItemModel> PedidoItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new EmpresaUnidadeMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.ApplyConfiguration(new MaxWebApi.Data.Map.Pessoa.PessoaTipoMap());
            modelBuilder.ApplyConfiguration(new MaxWebApi.Data.Map.Pessoa.PessoaContribuinteMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());

            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ProdutoDepartamentoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new NcmMap());
            modelBuilder.ApplyConfiguration(new SituacaoMap());

            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
