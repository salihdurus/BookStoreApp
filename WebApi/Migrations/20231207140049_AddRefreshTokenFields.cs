using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRefreshTokenFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ec0a703-907f-47fc-b730-5ebb23a4ca44", "38d81f00-63da-4b39-87f1-9f2f84593730", "Editor", "EDITOR" },
                    { "abda4379-dd0f-44d9-be66-430d19105ec2", "9edec510-10ee-4a43-8c2a-344dc7c7319f", "Admin", "ADMIN" },
                    { "dbe91f50-c470-45dd-99ff-9d0e0938fb06", "a97ef9bf-7e3c-4479-8a85-3b8f761670e7", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ec0a703-907f-47fc-b730-5ebb23a4ca44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abda4379-dd0f-44d9-be66-430d19105ec2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe91f50-c470-45dd-99ff-9d0e0938fb06");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

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
    }
}
