using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameStoreApp.Migrations
{
    public partial class IncluirDataEntregaPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PedidoEntregueEm",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagemThumbnailUrl",
                table: "Jogos",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedidoEntregueEm",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "ImagemThumbnailUrl",
                table: "Jogos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
