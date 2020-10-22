﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperService_BackEnd;

namespace SuperService_BackEnd.Migrations
{
    [DbContext(typeof(SuperServiceContext))]
    [Migration("20200930114136_initial_setup")]
    partial class initial_setup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperService_BackEnd.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double>("Fat")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberInStock")
                        .HasColumnType("int");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.Property<double>("Salt")
                        .HasColumnType("float");

                    b.Property<double>("Sugar")
                        .HasColumnType("float");

                    b.HasKey("IngredientID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.Item", b =>
                {
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.ItemIngredients", b =>
                {
                    b.Property<int>("ItemIngredientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IngredientID")
                        .HasColumnType("int");

                    b.Property<int?>("ItemID")
                        .HasColumnType("int");

                    b.HasKey("ItemIngredientID");

                    b.HasIndex("IngredientID");

                    b.HasIndex("ItemID");

                    b.ToTable("ItemIngredients");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("TableID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderItemsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemID")
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.HasKey("OrderItemsID");

                    b.HasIndex("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.Table", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ID");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.ItemIngredients", b =>
                {
                    b.HasOne("SuperService_BackEnd.Models.Ingredient", "Ingredient")
                        .WithMany("ItemIngredients")
                        .HasForeignKey("IngredientID");

                    b.HasOne("SuperService_BackEnd.Models.Item", "Item")
                        .WithMany("ItemIngredients")
                        .HasForeignKey("ItemID");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.Order", b =>
                {
                    b.HasOne("SuperService_BackEnd.Models.Table", null)
                        .WithMany("Orders")
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.OrderItems", b =>
                {
                    b.HasOne("SuperService_BackEnd.Models.Item", "Item")
                        .WithMany("Orders")
                        .HasForeignKey("ItemID");

                    b.HasOne("SuperService_BackEnd.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderID");
                });

            modelBuilder.Entity("SuperService_BackEnd.Models.User", b =>
                {
                    b.HasOne("SuperService_BackEnd.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeID");
                });
#pragma warning restore 612, 618
        }
    }
}
