using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMSOnlineStore.Infrastructure.Migrations
{
    public partial class CreateImageInItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "BaseEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "BaseEntity",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BaseEntity",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "BaseEntity",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "BaseEntity",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BaseEntity",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BaseEntity",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UnitOfMeasureId",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Vat",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Order_Discount",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Statue",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tax",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxValue",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderDetail_Price",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderDetail_Quantity",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetail_UnitOfMeasureId",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure_Description",
                table: "BaseEntity",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure_Name",
                table: "BaseEntity",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User_Description",
                table: "BaseEntity",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "BaseEntity",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "BaseEntity",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Price",
                table: "BaseEntity",
                column: "Price",
                unique: true,
                filter: "[Price] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UnitOfMeasureId",
                table: "BaseEntity",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ItemId",
                table: "BaseEntity",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_OrderId",
                table: "BaseEntity",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_OrderDetail_UnitOfMeasureId",
                table: "BaseEntity",
                column: "OrderDetail_UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UnitOfMeasure_Name",
                table: "BaseEntity",
                column: "UnitOfMeasure_Name",
                unique: true,
                filter: "[UnitOfMeasure_Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Email",
                table: "BaseEntity",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_UnitOfMeasureId",
                table: "BaseEntity",
                column: "UnitOfMeasureId",
                principalTable: "BaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_UserId",
                table: "BaseEntity",
                column: "UserId",
                principalTable: "BaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_ItemId",
                table: "BaseEntity",
                column: "ItemId",
                principalTable: "BaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_OrderId",
                table: "BaseEntity",
                column: "OrderId",
                principalTable: "BaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_OrderDetail_UnitOfMeasureId",
                table: "BaseEntity",
                column: "OrderDetail_UnitOfMeasureId",
                principalTable: "BaseEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_UnitOfMeasureId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_ItemId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_OrderId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_OrderDetail_UnitOfMeasureId",
                table: "BaseEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Price",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UnitOfMeasureId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_ItemId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_OrderId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_OrderDetail_UnitOfMeasureId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UnitOfMeasure_Name",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Email",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Vat",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Order_Discount",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Statue",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Tax",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OrderDetail_Price",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OrderDetail_Quantity",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "OrderDetail_UnitOfMeasureId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure_Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure_Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "User_Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statue = table.Column<int>(type: "int", nullable: false),
                    Tax = table.Column<int>(type: "int", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnitOfMeasureId",
                table: "Items",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UnitOfMeasureId",
                table: "OrderDetails",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasures_Name",
                table: "UnitOfMeasures",
                column: "Name",
                unique: true);
        }
    }
}
