using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSOnlineStore.Infrastructure.Migrations
{
    public partial class CreateUserInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderDetails",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "InCart",
                table: "OrderDetails",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf773851-4070-41d9-9808-099258d561b4", "AQAAAAEAACcQAAAAEDwfxizKdAlCmx8CzyQURXmfgP5pBCYnlLjzvcm8yrT4fmmM28hEylzGGBS3I9EzHg==", "5869fda0-4811-461d-9b3f-41c4392c3af0" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserId1",
                table: "OrderDetails",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_AspNetUsers_UserId1",
                table: "OrderDetails",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_AspNetUsers_UserId1",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_UserId1",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "InCart",
                table: "OrderDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f82ea23e-406f-4638-80c3-ed4e297fe62c", "AQAAAAEAACcQAAAAEOc3T6WrcZUdbtluWyKqPMbsDjH4NzA7kWkTIw5bLVnmKNPqvSGk0KvElBlb2ANN0A==", "ed44b638-6883-4303-8dee-8cbcd4e0a4c7" });
        }
    }
}
