using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSOnlineStore.Infrastructure.Migrations
{
    public partial class CreateDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "OrderDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ceb8c5e-1ea6-4cf3-81a0-d0bd201a5487", "AQAAAAEAACcQAAAAEApQ6/BNUaZavxgK7XWfr/kt9eVTjIc1ktBepXyHVdDoC5PAc40Uh4oMX6lFS9F/VA==", "8019c4e9-42a1-4b03-83fb-5f6462445add" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf773851-4070-41d9-9808-099258d561b4", "AQAAAAEAACcQAAAAEDwfxizKdAlCmx8CzyQURXmfgP5pBCYnlLjzvcm8yrT4fmmM28hEylzGGBS3I9EzHg==", "5869fda0-4811-461d-9b3f-41c4392c3af0" });
        }
    }
}
