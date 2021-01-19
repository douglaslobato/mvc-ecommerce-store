using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreApp.Migrations
{
    public partial class PedidoAddColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TtotalItensPedido",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TtotalItensPedido",
                table: "Pedidos");
        }
    }
}
