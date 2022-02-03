using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalogo_Blazor.Server.Migrations.Identity
{
    public partial class CriaRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00f05f70-caee-48fc-a000-fe30ac63fab4", "e366fccd-34d3-4f28-b3cd-ea6816da8411", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ca6513cc-5565-44d5-a220-59ed3ff27e92", "841d32ac-952b-4c50-9d9f-67f8542864bb", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f05f70-caee-48fc-a000-fe30ac63fab4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca6513cc-5565-44d5-a220-59ed3ff27e92");
        }
    }
}
