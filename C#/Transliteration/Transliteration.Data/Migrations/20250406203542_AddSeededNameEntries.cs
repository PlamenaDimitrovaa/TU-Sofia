using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Transliteration.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeededNameEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "NameEntries",
                columns: new[] { "Id", "NameOriginal", "NameTransliterated" },
                values: new object[,]
                {
                    { 1, "Иван", "Ivan" },
                    { 2, "Мария", "Maria" },
                    { 3, "Петя", "Petya" },
                    { 4, "ПламенА", "Plamena" },
                    { 5, "PLAMENA", "Plamena" },
                    { 6, "PetyA", "Petya" },
                    { 7, "Георги", "Georgi" },
                    { 8, "Georgi", "Georgi" },
                    { 9, "Daniel", "Daniel" },
                    { 10, "Даниел", "Daniel" },
                    { 11, "Yoana", "Yoana" },
                    { 12, "Йоана", "Yoana" },
                    { 13, "Кристиян", "Kristiyan" },
                    { 14, "Martin", "Martin" },
                    { 15, "Мартин", "Martin" },
                    { 16, "пЛамЕна", "Plamena" },
                    { 17, "Kristian", "Kristian" },
                    { 18, "Кристиан", "Kristian" },
                    { 19, "SimeoN", "Simeon" },
                    { 20, "Симеон", "Simeon" },
                    { 21, "Александър", "Aleksandar" },
                    { 22, "Aleksandar", "Aleksandar" },
                    { 23, "София", "Sofia" },
                    { 24, "Sofia", "Sofia" },
                    { 25, "НикоЛ", "Nikol" },
                    { 26, "Илия", "Ilia" },
                    { 27, "Ilia", "Ilia" },
                    { 28, "Виктория", "Viktoria" },
                    { 29, "Viktoria", "Viktoria" },
                    { 30, "IvaylA", "Ivayla" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "NameEntries",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
