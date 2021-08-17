﻿// <auto-generated />
using System;
using DMSOnlineStore.Infrastructure.Data.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMSOnlineStore.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210817110447_CreateImageInItem")]
    partial class CreateImageInItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DMSOnlineStore.Core.Models.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseEntity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseEntity");
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.Item", b =>
                {
                    b.HasBaseType("DMSOnlineStore.Core.Models.BaseEntity");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UnitOfMeasureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Vat")
                        .HasColumnType("decimal(18,2)");

                    b.HasIndex("Price")
                        .IsUnique()
                        .HasFilter("[Price] IS NOT NULL");

                    b.HasIndex("UnitOfMeasureId");

                    b.HasDiscriminator().HasValue("Item");
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.Order", b =>
                {
                    b.HasBaseType("DMSOnlineStore.Core.Models.BaseEntity");

                    b.Property<decimal>("Discount")
                        .HasColumnName("Order_Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Statue")
                        .HasColumnType("int");

                    b.Property<int>("Tax")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Order");
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.OrderDetail", b =>
                {
                    b.HasBaseType("DMSOnlineStore.Core.Models.BaseEntity");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnName("OrderDetail_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnName("OrderDetail_Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UnitOfMeasureId")
                        .HasColumnName("OrderDetail_UnitOfMeasureId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UnitOfMeasureId");

                    b.HasDiscriminator().HasValue("OrderDetail");
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.UnitOfMeasure", b =>
                {
                    b.HasBaseType("DMSOnlineStore.Core.Models.BaseEntity");

                    b.Property<string>("Description")
                        .HasColumnName("UnitOfMeasure_Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("UnitOfMeasure_Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[UnitOfMeasure_Name] IS NOT NULL");

                    b.HasDiscriminator().HasValue("UnitOfMeasure");
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.User", b =>
                {
                    b.HasBaseType("DMSOnlineStore.Core.Models.BaseEntity");

                    b.Property<string>("Description")
                        .HasColumnName("User_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("User_Name")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.Item", b =>
                {
                    b.HasOne("DMSOnlineStore.Core.Models.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("Items")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.Order", b =>
                {
                    b.HasOne("DMSOnlineStore.Core.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("DMSOnlineStore.Core.Models.OrderDetail", b =>
                {
                    b.HasOne("DMSOnlineStore.Core.Models.Item", "Item")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DMSOnlineStore.Core.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DMSOnlineStore.Core.Models.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("OrderDetails")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
