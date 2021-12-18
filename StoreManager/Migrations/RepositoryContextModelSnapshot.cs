﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StoreManager.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Entities.Models.Customers", b =>
                {
                    b.Property<int>("CustomersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CreditLimit")
                        .HasColumnType("int");

                    b.Property<string>("CustomersName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EmployeeIdFK")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PostalCode")
                        .HasColumnType("char(36)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CustomersId");

                    b.HasIndex("EmployeeIdFK");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Entities.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OfficeIdFK")
                        .HasColumnType("int");

                    b.Property<string>("ReportsTo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EmployeeId");

                    b.HasIndex("OfficeIdFK");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Entities.Models.Offices", b =>
                {
                    b.Property<int>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PostalCode")
                        .HasColumnType("char(36)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Territory")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OfficeId");

                    b.ToTable("offices");
                });

            modelBuilder.Entity("Entities.Models.OrderDetails", b =>
                {
                    b.Property<Guid>("ProductCodeFK")
                        .HasColumnType("char(36)");

                    b.Property<int>("OrderLineNumber")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumberFK")
                        .HasColumnType("int");

                    b.Property<int>("PriceEach")
                        .HasColumnType("int");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int");

                    b.HasKey("ProductCodeFK");

                    b.HasIndex("OrderNumberFK")
                        .IsUnique();

                    b.ToTable("orderdetails");
                });

            modelBuilder.Entity("Entities.Models.Orders", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CustomersFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrderNumber");

                    b.HasIndex("CustomersFK");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Entities.Models.Payments", b =>
                {
                    b.Property<int>("CustomersIdFK")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CheckNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CustomersIdFK");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("Entities.Models.ProductLines", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HtmlDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TextDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductId");

                    b.ToTable("productlines");
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.Property<Guid>("ProductCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BuyPrice")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MSRP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductDiscription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProductIdFK")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductScale")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductVendor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("QuantityInStock")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductCode");

                    b.HasIndex("ProductIdFK");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Entities.Models.Customers", b =>
                {
                    b.HasOne("Entities.Models.Employees", "Employees")
                        .WithMany("Customers")
                        .HasForeignKey("EmployeeIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entities.Models.Employees", b =>
                {
                    b.HasOne("Entities.Models.Employees", "EmployeesBoss")
                        .WithMany("EmployeesOfMine")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Offices", "Offices")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeesBoss");

                    b.Navigation("Offices");
                });

            modelBuilder.Entity("Entities.Models.OrderDetails", b =>
                {
                    b.HasOne("Entities.Models.Orders", "Orders")
                        .WithOne("OrderDetails")
                        .HasForeignKey("Entities.Models.OrderDetails", "OrderNumberFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Products", "Products")
                        .WithOne("OrderDetails")
                        .HasForeignKey("Entities.Models.OrderDetails", "ProductCodeFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Orders", b =>
                {
                    b.HasOne("Entities.Models.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Entities.Models.Payments", b =>
                {
                    b.HasOne("Entities.Models.Customers", "Customers")
                        .WithOne("Payments")
                        .HasForeignKey("Entities.Models.Payments", "CustomersIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.HasOne("Entities.Models.ProductLines", "ProductLines")
                        .WithMany("Products")
                        .HasForeignKey("ProductIdFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductLines");
                });

            modelBuilder.Entity("Entities.Models.Customers", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Entities.Models.Employees", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("EmployeesOfMine");
                });

            modelBuilder.Entity("Entities.Models.Offices", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Entities.Models.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Entities.Models.ProductLines", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
