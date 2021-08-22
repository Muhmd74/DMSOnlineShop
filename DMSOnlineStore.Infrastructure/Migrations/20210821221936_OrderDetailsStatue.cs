using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSOnlineStore.Infrastructure.Migrations
{
    public partial class OrderDetailsStatue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InCart",
                table: "OrderDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f82ea23e-406f-4638-80c3-ed4e297fe62c", "AQAAAAEAACcQAAAAEOc3T6WrcZUdbtluWyKqPMbsDjH4NzA7kWkTIw5bLVnmKNPqvSGk0KvElBlb2ANN0A==", "ed44b638-6883-4303-8dee-8cbcd4e0a4c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InCart",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13572456-6511-47af-9774-d1055004ce52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88ad8133-3fe9-48d0-b77a-444e64867606", "AQAAAAEAACcQAAAAEOj5uGXRAyggmsYldBOvX+R1sXy7ZmDqb5HI7o2qK7ElOdvn6yJa58v/kEKs4Z1O8A==", "d6b4b4c7-b8b5-437f-af22-86dfaa2a0ae1" });
        }
    }
}
