using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pedidoServiceApi.Migrations
{
    /// <inheritdoc />
    public partial class FixItens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idPedido",
                table: "ItensPedidos");

            migrationBuilder.AddColumn<long>(
                name: "NumeroDoPedido",
                table: "ItensPedidos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDoPedido",
                table: "ItensPedidos");

            migrationBuilder.AddColumn<int>(
                name: "idPedido",
                table: "ItensPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
