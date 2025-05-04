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
                    DateDisponibilité = table.Column<DateOnly>(type: "date", nullable: true),
                    PrixAchat = table.Column<int>(type: "int", nullable: false),
                    Reparation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoutReparation = table.Column<int>(type: "int", nullable: false),
                    DateVente = table.Column<DateOnly>(type: "date", nullable: true),
                    EstDisponible = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Vin);
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voitures");


        }
    }
}
