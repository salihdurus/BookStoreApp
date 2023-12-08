using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class AddRefreshTokenFieldsN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3bb309f-ab4c-48a2-8f08-d440fcc48bd6", "d952d27a-f101-466a-8a2f-0842c7793bcb", "User", "USER" },
                    { "d5698661-b788-48a5-a9a4-f44710e23427", "7545a725-4afd-429c-a85b-c3671f8087d2", "Admin", "ADMIN" },
                    { "ea97bc2d-f0d9-48e7-a928-1eee59f1bb24", "01a4697d-5296-4c5d-94ad-97bd32aa42af", "Editor", "EDITOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3bb309f-ab4c-48a2-8f08-d440fcc48bd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5698661-b788-48a5-a9a4-f44710e23427");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea97bc2d-f0d9-48e7-a928-1eee59f1bb24");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

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
    }
}
