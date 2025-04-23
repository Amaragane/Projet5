using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet5.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenerateStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Vin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modele = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeModel = table.Column<int>(type: "int", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAchat = table.Column<DateOnly>(type: "date", nullable: false),
                    DateDisponibilité = table.Column<DateOnly>(type: "date", nullable: false),
                    PrixAchat = table.Column<int>(type: "int", nullable: false),
                    Reparation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoutReparation = table.Column<int>(type: "int", nullable: false),
                    EstDisponible = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Vin);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28d32087-547f-49ea-9065-e456d5ee1a68", "fcdc8dee-2982-4924-88cf-b24a83d53e38", "Admin", "ADMIN" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28d32087-547f-49ea-9065-e456d5ee1a68");
        }
    }
}
