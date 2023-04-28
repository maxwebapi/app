using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class pedidoitemproduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "PedidoItem",
                type: "char(36)",
                nullable: true,
                comment: "ID do produto",
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoItem_Produto_ProdutoId",
                table: "PedidoItem",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoItem_Produto_ProdutoId",
                table: "PedidoItem");

            migrationBuilder.DropIndex(
                name: "IX_PedidoItem_ProdutoId",
                table: "PedidoItem");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "PedidoItem");
        }
    }
}
