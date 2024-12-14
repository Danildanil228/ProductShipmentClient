﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductShipmentAPI.Data;

#nullable disable

namespace ProductShipmentAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductShipmentAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Товар1",
                            Price = 100m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Товар2",
                            Price = 200m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Товар3",
                            Price = 300m
                        });
                });

            modelBuilder.Entity("ProductShipmentAPI.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShipmentId"));

                    b.Property<decimal>("BatchCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BatchSize")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Store")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipmentId");

                    b.ToTable("Shipments");

                    b.HasData(
                        new
                        {
                            ShipmentId = 1,
                            BatchCost = 5000m,
                            BatchSize = 50,
                            ProductId = 1,
                            ShipmentDate = new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Store = "name1"
                        },
                        new
                        {
                            ShipmentId = 2,
                            BatchCost = 6000m,
                            BatchSize = 30,
                            ProductId = 1,
                            ShipmentDate = new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Store = "name2"
                        },
                        new
                        {
                            ShipmentId = 3,
                            BatchCost = 6000m,
                            BatchSize = 20,
                            ProductId = 1,
                            ShipmentDate = new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Store = "name3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
