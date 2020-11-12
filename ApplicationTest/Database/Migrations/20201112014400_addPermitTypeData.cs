using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class addPermitTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermitType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Licencia Medica" });

            migrationBuilder.InsertData(
                table: "PermitType",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Estudios" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermitType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PermitType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
