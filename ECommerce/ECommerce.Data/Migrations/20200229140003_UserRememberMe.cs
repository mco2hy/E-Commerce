using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Data.Migrations
{
    public partial class UserRememberMe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AutoLoginKey",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 2, 29, 14, 0, 3, 713, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutoLoginKey",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 2, 23, 14, 15, 26, 343, DateTimeKind.Utc));
        }
    }
}
