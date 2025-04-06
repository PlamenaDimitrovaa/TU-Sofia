using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transliteration.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NameEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOriginal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameTransliterated = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Query = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NameEntries_NameOriginal",
                table: "NameEntries",
                column: "NameOriginal");

            migrationBuilder.CreateIndex(
                name: "IX_NameEntries_NameTransliterated",
                table: "NameEntries",
                column: "NameTransliterated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameEntries");

            migrationBuilder.DropTable(
                name: "SearchLogs");
        }
    }
}
