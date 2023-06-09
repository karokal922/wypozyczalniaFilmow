﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wypozyczalniaDAL.Models;

#nullable disable

namespace wypozyczalniaDAL.Migrations
{
    [DbContext(typeof(MovieRentalContext))]
    [Migration("20230330123031_init0")]
    partial class init0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.Property<int>("CategoriesId_Category")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId_Movie")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId_Category", "MoviesId_Movie");

                    b.HasIndex("MoviesId_Movie");

                    b.ToTable("CategoryMovie");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Category", b =>
                {
                    b.Property<int>("Id_Category")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Category"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_Category");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Movie", b =>
                {
                    b.Property<int>("Id_Movie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Movie"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Premiere")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RentId_Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Movie");

                    b.HasIndex("RentId_Rate");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Payment", b =>
                {
                    b.Property<int>("Id_Payment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Payment"));

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id_Payment");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Rate", b =>
                {
                    b.Property<int>("Id_Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Rate"));

                    b.Property<string>("Comment")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("MovieId_Movie")
                        .HasColumnType("int");

                    b.Property<int>("Movie_ID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId_User")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<double>("_Rate")
                        .HasColumnType("float");

                    b.HasKey("Id_Rate");

                    b.HasIndex("MovieId_Movie");

                    b.HasIndex("UserId_User");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Rent", b =>
                {
                    b.Property<int>("Id_Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Rate"));

                    b.Property<int>("Payment_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Id_Rate");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.User", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_User"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CategoryMovie", b =>
                {
                    b.HasOne("wypozyczalniaDAL.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId_Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wypozyczalniaDAL.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId_Movie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Movie", b =>
                {
                    b.HasOne("wypozyczalniaDAL.Models.Rent", null)
                        .WithMany("Movies")
                        .HasForeignKey("RentId_Rate");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Rate", b =>
                {
                    b.HasOne("wypozyczalniaDAL.Models.Movie", null)
                        .WithMany("Ratings")
                        .HasForeignKey("MovieId_Movie");

                    b.HasOne("wypozyczalniaDAL.Models.User", null)
                        .WithMany("Rates")
                        .HasForeignKey("UserId_User");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Movie", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.Rent", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("wypozyczalniaDAL.Models.User", b =>
                {
                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
