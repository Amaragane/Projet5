using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet5.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenommerChampEstAdministrateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstAdministateur",
                table: "Users",
                newName: "EstAdministrateur");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstAdministrateur",
                table: "Users",
                newName: "EstAdministateur");


        }
    }
}
