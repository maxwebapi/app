using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class maxwebapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Nome completo")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false, comment: "UF unidade federativa")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ncm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cest = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false, comment: "Cest")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: false, comment: "Descrição")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ncm", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PessoaContribuinte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "Descrição")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaContribuinte", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PessoaTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "Descrição")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaTipo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Situacao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Situação")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Nome")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SituacaoId = table.Column<int>(type: "int", nullable: false, comment: "ID de situação")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EmpresaUnidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa unidade")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Nome da empresa unidade")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<int>(type: "int", nullable: true, comment: "ID da empresa"),
                    CidadeId = table.Column<int>(type: "int", nullable: false, comment: "ID da cidade"),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Código de endereçamento posta CEP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nome do bairro")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Endereço completo (Rua/Av/etc...")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Número do endereço")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, comment: "Complemento do endereço")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Email")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "CNPJ cadastro de pessoa jurídica")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ie = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "IE inscrição estauda")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaUnidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaUnidade_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaUnidade_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID da pessoa", collation: "ascii_general_ci"),
                    PessoaId = table.Column<int>(type: "int", nullable: false, comment: "ID sequencia de pessoa por empresa"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Nome da pessoa")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa"),
                    PessoaTipoId = table.Column<int>(type: "int", nullable: false, comment: "ID do tipo de pessoa"),
                    PessoaContribuinteId = table.Column<int>(type: "int", nullable: false, comment: "ID do tipo de contribuinte"),
                    SituacaoId = table.Column<int>(type: "int", nullable: false, comment: "ID da situação"),
                    CidadeId = table.Column<int>(type: "int", nullable: false, comment: "ID da cidade"),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Código de endereçamento posta CEP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nome do bairro")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Endereço completo (Rua/Av/etc...")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "Número do endereço")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, comment: "Complemento do endereço")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Email")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true, comment: "CPF")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rg = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "RG documento de identidade")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "CNPJ")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ie = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "IE inscrição estadual")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelComercial = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "Telefone comercial")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelContato = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "Telefone para contato")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelCelular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "Telefone celular")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cliente = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true, comment: "Cliente")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vendedor = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true, comment: "Vendedor")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "Data de cadastro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_PessoaContribuinte_PessoaContribuinteId",
                        column: x => x.PessoaContribuinteId,
                        principalTable: "PessoaContribuinte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_PessoaTipo_PessoaTipoId",
                        column: x => x.PessoaTipoId,
                        principalTable: "PessoaTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoa_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoDepartamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa"),
                    ProdutoDepartamento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Departamento de produto")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoDepartamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoDepartamento_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoGrupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(type: "int", nullable: true, comment: "ID da empresa"),
                    ProdutoGrupo = table.Column<string>(type: "longtext", nullable: true, comment: "Grupo de produto")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoGrupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoGrupo_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID do pedido", collation: "ascii_general_ci"),
                    PedidoId = table.Column<int>(type: "int", nullable: false, comment: "ID sequencia do pedido por empresa"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa"),
                    EmpresaUnidadeId = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa unidade"),
                    PessoaId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID do cliente", collation: "ascii_general_ci"),
                    VendedorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "ID do vendedor", collation: "ascii_general_ci"),
                    SituacaoId = table.Column<int>(type: "int", nullable: false, comment: "ID da sutuacao"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Dada de cadastro"),
                    TotalProduto = table.Column<double>(type: "double", nullable: false, comment: "Total de Produto"),
                    TotalDesconto = table.Column<double>(type: "double", nullable: false, comment: "Total de Desconto"),
                    PercDesconto = table.Column<double>(type: "double", nullable: false, comment: "Percentual de Desconto"),
                    TotalLiquido = table.Column<double>(type: "double", nullable: false, comment: "Total Liquido")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_EmpresaUnidade_EmpresaUnidadeId",
                        column: x => x.EmpresaUnidadeId,
                        principalTable: "EmpresaUnidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID", collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Email")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Senha")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PessoaId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID da pessoa", collation: "ascii_general_ci"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa"),
                    SituacaoId = table.Column<int>(type: "int", nullable: false, comment: "ID da situacao")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID", collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Nome do produto")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "Complemento")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false, comment: "Id do Produto por Empresa"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false, comment: "ID da empresa"),
                    SituacaoId = table.Column<int>(type: "int", nullable: false, comment: "ID da situação"),
                    ProdutoGrupoId = table.Column<int>(type: "int", nullable: false, comment: "ID do grupo"),
                    ProdutoDepartamentoId = table.Column<int>(type: "int", nullable: false, comment: "ID do departamento"),
                    NcmId = table.Column<int>(type: "int", nullable: false, comment: "ID do NCM"),
                    Cest = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true, comment: "CEST")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ean = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true, comment: "EAN (código de barras)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Referencia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Referência")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoFabricante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "Código do fabricante")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecoCusto = table.Column<double>(type: "double", nullable: false, comment: "Preço de Custo"),
                    MargemLucro = table.Column<double>(type: "double", nullable: false, comment: "Margem de Lucro"),
                    PrecoVenda = table.Column<double>(type: "double", nullable: false, comment: "Preço de Venda"),
                    PesoLiquido = table.Column<double>(type: "double", nullable: true, comment: "Peso Líquido"),
                    PesoBruto = table.Column<double>(type: "double", nullable: true, comment: "Peso Bruto"),
                    EstoqueMinimo = table.Column<double>(type: "double", nullable: true, comment: "Estoque Mínimo"),
                    EstoqueMaximo = table.Column<double>(type: "double", nullable: true, comment: "Estoque Máximo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Ncm_NcmId",
                        column: x => x.NcmId,
                        principalTable: "Ncm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_ProdutoDepartamento_ProdutoDepartamentoId",
                        column: x => x.ProdutoDepartamentoId,
                        principalTable: "ProdutoDepartamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_ProdutoGrupo_ProdutoGrupoId",
                        column: x => x.ProdutoGrupoId,
                        principalTable: "ProdutoGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "ID do pedido item")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "ID do pedido", collation: "ascii_general_ci"),
                    Quantidade = table.Column<double>(type: "double", nullable: false, comment: "Quantidade"),
                    PrecoVenda = table.Column<double>(type: "double", nullable: false, comment: "Preço de venda"),
                    PrecoUnitario = table.Column<double>(type: "double", nullable: false, comment: "Perço unitario"),
                    TotalProdutoItem = table.Column<double>(type: "double", nullable: false, comment: "Total do Item")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_SituacaoId",
                table: "Empresa",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUnidade_CidadeId",
                table: "EmpresaUnidade",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaUnidade_EmpresaId",
                table: "EmpresaUnidade",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EmpresaId",
                table: "Pedido",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_EmpresaUnidadeId",
                table: "Pedido",
                column: "EmpresaUnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_PessoaId",
                table: "Pedido",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_SituacaoId",
                table: "Pedido",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_PedidoId",
                table: "PedidoItem",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_CidadeId",
                table: "Pessoa",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EmpresaId",
                table: "Pessoa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaContribuinteId",
                table: "Pessoa",
                column: "PessoaContribuinteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaTipoId",
                table: "Pessoa",
                column: "PessoaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_SituacaoId",
                table: "Pessoa",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EmpresaId",
                table: "Produto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_NcmId",
                table: "Produto",
                column: "NcmId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ProdutoDepartamentoId",
                table: "Produto",
                column: "ProdutoDepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ProdutoGrupoId",
                table: "Produto",
                column: "ProdutoGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SituacaoId",
                table: "Produto",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoDepartamento_EmpresaId",
                table: "ProdutoDepartamento",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoGrupo_EmpresaId",
                table: "ProdutoGrupo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpresaId",
                table: "Usuario",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_SituacaoId",
                table: "Usuario",
                column: "SituacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Ncm");

            migrationBuilder.DropTable(
                name: "ProdutoDepartamento");

            migrationBuilder.DropTable(
                name: "ProdutoGrupo");

            migrationBuilder.DropTable(
                name: "EmpresaUnidade");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "PessoaContribuinte");

            migrationBuilder.DropTable(
                name: "PessoaTipo");

            migrationBuilder.DropTable(
                name: "Situacao");
        }
    }
}
