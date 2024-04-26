﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RP_back.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240426220021_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Health", b =>
                {
                    b.Property<DateTime>("sync")
                        .HasColumnType("datetime2");

                    b.ToTable("Health");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductCostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProductSalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ProductionItem", b =>
                {
                    b.Property<int>("ProductionItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionItemId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionOrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool?>("Waste")
                        .HasColumnType("bit");

                    b.HasKey("ProductionItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductionOrderId");

                    b.ToTable("ProductionItem");
                });

            modelBuilder.Entity("ProductionOrder", b =>
                {
                    b.Property<int>("ProductionOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionOrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("ProductionOrderDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ProductionOrderExpectedCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionOrderExpectedStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductionOrderId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProductionOrder");
                });

            modelBuilder.Entity("Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("SupplierAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierCNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ProductionItem", b =>
                {
                    b.HasOne("Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductionOrder", "ProductionOrder")
                        .WithMany()
                        .HasForeignKey("ProductionOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductionOrder");
                });

            modelBuilder.Entity("ProductionOrder", b =>
                {
                    b.HasOne("Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}