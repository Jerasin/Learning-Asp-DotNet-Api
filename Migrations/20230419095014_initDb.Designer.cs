﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestApiSample.src.Models;

#nullable disable

namespace RestApiSample.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20230419095014_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RestApiSample.src.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("Img")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Active");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("products");
                });

            modelBuilder.Entity("RestApiSample.src.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Password")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("RestApiSample.src.Models.WareHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("CreatedAt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("varchar(550)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("longtext");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("warehouse");
                });

            modelBuilder.Entity("RestApiSample.src.Models.WareHouse", b =>
                {
                    b.HasOne("RestApiSample.src.Models.Product", "Product")
                        .WithOne("WareHouse")
                        .HasForeignKey("RestApiSample.src.Models.WareHouse", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("RestApiSample.src.Models.Product", b =>
                {
                    b.Navigation("WareHouse")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
