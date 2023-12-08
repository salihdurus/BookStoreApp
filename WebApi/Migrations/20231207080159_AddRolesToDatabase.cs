using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRolesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10a2ea5b-cd82-441e-9b07-52953e30cd78", "50681026-fcfe-427b-ba10-2b5ced0cf1fc", "Admin", "ADMIN" },
                    { "1a7e9e9d-4f8d-4213-a5be-a0bdccee63d4", "d49045c7-a673-4337-8d3f-6e1ef164494f", "Editor", "EDITOR" },
                    { "76ef1802-6c51-4adf-a0f7-6c8616af88ba", "e4a40218-8add-4ed5-94bb-71e8981fbe64", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10a2ea5b-cd82-441e-9b07-52953e30cd78");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a7e9e9d-4f8d-4213-a5be-a0bdccee63d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76ef1802-6c51-4adf-a0f7-6c8616af88ba");
        }
    }
}
