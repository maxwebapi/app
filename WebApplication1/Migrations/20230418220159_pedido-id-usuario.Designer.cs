﻿// <auto-generated />
using System;
using AppApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MaxWebApi.Migrations
{
    [DbContext(typeof(MaxWebApiDBContext))]
    [Migration("20230418220159_pedido-id-usuario")]
    partial class pedidoidusuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MaxWebApi.Models.Empresa.EmpresaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Nome");

                    b.Property<int?>("SituacaoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID de situação");

                    b.HasKey("Id");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("MaxWebApi.Models.Empresa.EmpresaUnidadeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID da empresa unidade");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nome do bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasComment("Código de endereçamento posta CEP");

                    b.Property<int?>("CidadeId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da cidade");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("CNPJ cadastro de pessoa jurídica");

                    b.Property<string>("Complemento")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("Complemento do endereço");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Email");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Endereço completo (Rua/Av/etc...");

                    b.Property<string>("Ie")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("IE inscrição estauda");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Nome da empresa unidade");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasComment("Número do endereço");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("EmpresaUnidade");
                });

            modelBuilder.Entity("MaxWebApi.Models.Generico.CidadeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Nome completo");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)")
                        .HasComment("UF unidade federativa");

                    b.HasKey("Id");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("MaxWebApi.Models.Generico.NcmModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<string>("Cest")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasComment("Cest");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("varchar(1500)")
                        .HasComment("Descrição");

                    b.HasKey("Id");

                    b.ToTable("Ncm");
                });

            modelBuilder.Entity("MaxWebApi.Models.Generico.SituacaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Situação");

                    b.HasKey("Id");

                    b.ToTable("Situacao");
                });

            modelBuilder.Entity("MaxWebApi.Models.Pedido.PedidoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("ID do pedido");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)")
                        .HasComment("Dada de cadastro");

                    b.Property<int?>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<int?>("EmpresaUnidadeId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da empresa unidade");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int")
                        .HasComment("ID sequencia do pedido por empresa");

                    b.Property<double>("PercDesconto")
                        .HasColumnType("double")
                        .HasComment("Percentual de Desconto");

                    b.Property<Guid?>("PessoaId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("ID do cliente");

                    b.Property<int?>("SituacaoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da sutuacao");

                    b.Property<double>("TotalDesconto")
                        .HasColumnType("double")
                        .HasComment("Total de Desconto");

                    b.Property<double>("TotalLiquido")
                        .HasColumnType("double")
                        .HasComment("Total Liquido");

                    b.Property<double>("TotalProduto")
                        .HasColumnType("double")
                        .HasComment("Total de Produto");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("char(36)")
                        .HasComment("ID do usuário");

                    b.Property<Guid?>("VendedorId")
                        .HasColumnType("char(36)")
                        .HasComment("ID do vendedor");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EmpresaUnidadeId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("MaxWebApi.Models.PedidoItem.PedidoItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID do pedido item");

                    b.Property<Guid?>("PedidoId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("ID do pedido");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double")
                        .HasComment("Perço unitario");

                    b.Property<double>("PrecoVenda")
                        .HasColumnType("double")
                        .HasComment("Preço de venda");

                    b.Property<double>("Quantidade")
                        .HasColumnType("double")
                        .HasComment("Quantidade");

                    b.Property<double>("TotalProdutoItem")
                        .HasColumnType("double")
                        .HasComment("Total do Item");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("MaxWebApi.Models.Pessoa.PessoaContribuinteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("Descrição");

                    b.HasKey("Id");

                    b.ToTable("PessoaContribuinte");
                });

            modelBuilder.Entity("MaxWebApi.Models.Pessoa.PessoaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("ID da pessoa");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Nome do bairro");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasComment("Código de endereçamento posta CEP");

                    b.Property<int?>("CidadeId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da cidade");

                    b.Property<string>("Cliente")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasComment("Cliente");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("CNPJ");

                    b.Property<string>("Complemento")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasComment("Complemento do endereço");

                    b.Property<string>("Cpf")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)")
                        .HasComment("CPF");

                    b.Property<DateTime?>("DataCadastro")
                        .HasColumnType("datetime(6)")
                        .HasComment("Data de cadastro");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Email");

                    b.Property<int?>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Endereço completo (Rua/Av/etc...");

                    b.Property<string>("Ie")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("IE inscrição estadual");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Nome da pessoa");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasComment("Número do endereço");

                    b.Property<int?>("PessoaContribuinteId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID do tipo de contribuinte");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int")
                        .HasComment("ID sequencia de pessoa por empresa");

                    b.Property<int?>("PessoaTipoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID do tipo de pessoa");

                    b.Property<string>("Rg")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("RG documento de identidade");

                    b.Property<int?>("SituacaoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da situação");

                    b.Property<string>("TelCelular")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("Telefone celular");

                    b.Property<string>("TelComercial")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("Telefone comercial");

                    b.Property<string>("TelContato")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("Telefone para contato");

                    b.Property<string>("Vendedor")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasComment("Vendedor");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaContribuinteId");

                    b.HasIndex("PessoaTipoId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("MaxWebApi.Models.Pessoa.PessoaTipoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("Descrição");

                    b.HasKey("Id");

                    b.ToTable("PessoaTipo");
                });

            modelBuilder.Entity("MaxWebApi.Models.Produto.ProdutoDepartamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<int?>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<string>("ProdutoDepartamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Departamento de produto");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("ProdutoDepartamento");
                });

            modelBuilder.Entity("MaxWebApi.Models.Produto.ProdutoGrupoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("ID");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<string>("ProdutoGrupo")
                        .HasColumnType("longtext")
                        .HasComment("Grupo de produto");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("ProdutoGrupo");
                });

            modelBuilder.Entity("MaxWebApi.Models.Produto.ProdutoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("ID");

                    b.Property<string>("Cest")
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)")
                        .HasComment("CEST");

                    b.Property<string>("CodigoFabricante")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Código do fabricante");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Complemento");

                    b.Property<string>("Ean")
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)")
                        .HasComment("EAN (código de barras)");

                    b.Property<int?>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<double?>("EstoqueMaximo")
                        .HasColumnType("double")
                        .HasComment("Estoque Máximo");

                    b.Property<double?>("EstoqueMinimo")
                        .HasColumnType("double")
                        .HasComment("Estoque Mínimo");

                    b.Property<double?>("MargemLucro")
                        .IsRequired()
                        .HasColumnType("double")
                        .HasComment("Margem de Lucro");

                    b.Property<int?>("NcmId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID do NCM");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Nome do produto");

                    b.Property<double?>("PesoBruto")
                        .HasColumnType("double")
                        .HasComment("Peso Bruto");

                    b.Property<double?>("PesoLiquido")
                        .HasColumnType("double")
                        .HasComment("Peso Líquido");

                    b.Property<double?>("PrecoCusto")
                        .IsRequired()
                        .HasColumnType("double")
                        .HasComment("Preço de Custo");

                    b.Property<double?>("PrecoVenda")
                        .IsRequired()
                        .HasColumnType("double")
                        .HasComment("Preço de Venda");

                    b.Property<int?>("ProdutoDepartamentoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID do departamento");

                    b.Property<int?>("ProdutoGrupoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID do grupo");

                    b.Property<int?>("ProdutoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("Id do Produto por Empresa");

                    b.Property<string>("Referencia")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasComment("Referência");

                    b.Property<int?>("SituacaoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da situação");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("NcmId");

                    b.HasIndex("ProdutoDepartamentoId");

                    b.HasIndex("ProdutoGrupoId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MaxWebApi.Models.UsuarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("ID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasComment("Email");

                    b.Property<int?>("EmpresaId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da empresa");

                    b.Property<Guid?>("PessoaId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("ID da pessoa");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("Senha");

                    b.Property<int?>("SituacaoId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasComment("ID da situacao");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MaxWebApi.Models.Empresa.EmpresaModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Generico.SituacaoModel", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("MaxWebApi.Models.Empresa.EmpresaUnidadeModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Generico.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Cidade");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MaxWebApi.Models.Pedido.PedidoModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaUnidadeModel", "EmpresaUnidade")
                        .WithMany()
                        .HasForeignKey("EmpresaUnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Pessoa.PessoaModel", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Generico.SituacaoModel", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("EmpresaUnidade");

                    b.Navigation("Pessoa");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("MaxWebApi.Models.PedidoItem.PedidoItemModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Pedido.PedidoModel", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("MaxWebApi.Models.Pessoa.PessoaModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Generico.CidadeModel", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Pessoa.PessoaContribuinteModel", "PessoaContribuinte")
                        .WithMany()
                        .HasForeignKey("PessoaContribuinteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Pessoa.PessoaTipoModel", "PessoaTipo")
                        .WithMany()
                        .HasForeignKey("PessoaTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Generico.SituacaoModel", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Empresa");

                    b.Navigation("PessoaContribuinte");

                    b.Navigation("PessoaTipo");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("MaxWebApi.Models.Produto.ProdutoDepartamentoModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MaxWebApi.Models.Produto.ProdutoGrupoModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("MaxWebApi.Models.Produto.ProdutoModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Generico.NcmModel", "Ncm")
                        .WithMany()
                        .HasForeignKey("NcmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Produto.ProdutoDepartamentoModel", "ProdutoDepartamento")
                        .WithMany()
                        .HasForeignKey("ProdutoDepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Produto.ProdutoGrupoModel", "ProdutoGrupo")
                        .WithMany()
                        .HasForeignKey("ProdutoGrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Generico.SituacaoModel", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Ncm");

                    b.Navigation("ProdutoDepartamento");

                    b.Navigation("ProdutoGrupo");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("MaxWebApi.Models.UsuarioModel", b =>
                {
                    b.HasOne("MaxWebApi.Models.Empresa.EmpresaModel", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Pessoa.PessoaModel", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaxWebApi.Models.Generico.SituacaoModel", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Pessoa");

                    b.Navigation("Situacao");
                });
#pragma warning restore 612, 618
        }
    }
}
