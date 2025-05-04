using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionDepenses.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreateDepenseDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nature = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    NombreInvites = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depenses", x => x.Id);
                    table.CheckConstraint("CK_Depense_Distance_NonNull", "[Nature] != 0 OR [Distance] IS NOT NULL");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depenses");
        }
    }
}
