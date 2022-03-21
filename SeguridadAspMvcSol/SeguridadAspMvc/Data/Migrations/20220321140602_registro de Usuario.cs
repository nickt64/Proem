using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SeguridadAspMvc.Data.Migrations
{
    public partial class registrodeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "Clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "Clientes");
        }
    }
}
