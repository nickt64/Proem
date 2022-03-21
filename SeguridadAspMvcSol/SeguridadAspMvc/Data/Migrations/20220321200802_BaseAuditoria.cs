using Microsoft.EntityFrameworkCore.Migrations;

namespace SeguridadAspMvc.Data.Migrations
{
    public partial class BaseAuditoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioModificacion",
                table: "Clientes",
                newName: "ModificadoPor");

            migrationBuilder.RenameColumn(
                name: "UsuarioCreacion",
                table: "Clientes",
                newName: "CreadoPor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModificadoPor",
                table: "Clientes",
                newName: "UsuarioModificacion");

            migrationBuilder.RenameColumn(
                name: "CreadoPor",
                table: "Clientes",
                newName: "UsuarioCreacion");
        }
    }
}
