﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorApp.Data;

namespace RazorApp.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20200203183508_RowVersion")]
    partial class RowVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RazorApp.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FoundedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CompanyID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("RazorApp.Models.CompanyHQ", b =>
                {
                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("CompanyID");

                    b.ToTable("CompanyHQ");
                });

            modelBuilder.Entity("RazorApp.Models.Drink", b =>
                {
                    b.Property<int>("DrinkID")
                        .HasColumnType("int");

                    b.Property<int>("DrinkCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.HasKey("DrinkID");

                    b.HasIndex("DrinkCategoryID");

                    b.ToTable("Drink");
                });

            modelBuilder.Entity("RazorApp.Models.DrinkAssignment", b =>
                {
                    b.Property<int>("DrinkID")
                        .HasColumnType("int");

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.HasKey("DrinkID", "CompanyID");

                    b.HasIndex("CompanyID");

                    b.ToTable("DrinkAssignment");
                });

            modelBuilder.Entity("RazorApp.Models.DrinkCategory", b =>
                {
                    b.Property<int>("DrinkCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alcoholic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyID")
                        .HasColumnType("int");

                    b.Property<decimal>("MinProductionCost")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("DrinkCategoryID");

                    b.HasIndex("CompanyID");

                    b.ToTable("DrinkCategory");
                });

            modelBuilder.Entity("RazorApp.Models.Food", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("FoodName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("FoodID");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("RazorApp.Models.Menu", b =>
                {
                    b.Property<int>("MenuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrinkID")
                        .HasColumnType("int");

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int?>("HealthGrade")
                        .HasColumnType("int");

                    b.HasKey("MenuID");

                    b.HasIndex("DrinkID");

                    b.HasIndex("FoodID");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("RazorApp.Models.CompanyHQ", b =>
                {
                    b.HasOne("RazorApp.Models.Company", "Company")
                        .WithOne("CompanyHQ")
                        .HasForeignKey("RazorApp.Models.CompanyHQ", "CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RazorApp.Models.Drink", b =>
                {
                    b.HasOne("RazorApp.Models.DrinkCategory", "DrinkCategory")
                        .WithMany("Drinks")
                        .HasForeignKey("DrinkCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RazorApp.Models.DrinkAssignment", b =>
                {
                    b.HasOne("RazorApp.Models.Company", "Company")
                        .WithMany("DrinkAssignments")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorApp.Models.Drink", "Drink")
                        .WithMany("DrinkAssignments")
                        .HasForeignKey("DrinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RazorApp.Models.DrinkCategory", b =>
                {
                    b.HasOne("RazorApp.Models.Company", "CompanyHead")
                        .WithMany()
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("RazorApp.Models.Menu", b =>
                {
                    b.HasOne("RazorApp.Models.Drink", "Drink")
                        .WithMany("Menus")
                        .HasForeignKey("DrinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorApp.Models.Food", "Food")
                        .WithMany("Menus")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
