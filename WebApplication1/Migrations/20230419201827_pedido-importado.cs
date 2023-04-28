using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class pedidoimportado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Importado",
                table: "Pedido",
                type: "longtext",
                nullable: false,
                defaultValue: "N",
                comment: "Importado")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importado",
                table: "Pedido");
        }
    }
}
