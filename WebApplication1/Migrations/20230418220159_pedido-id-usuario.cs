using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class pedidoidusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Pedido",
                type: "char(36)",
                nullable: true,
                comment: "ID do usuário",
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Pedido");
        }
    }
}
