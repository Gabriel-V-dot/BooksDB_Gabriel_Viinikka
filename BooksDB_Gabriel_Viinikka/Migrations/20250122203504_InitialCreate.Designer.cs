﻿// <auto-generated />
using System;
using BooksDB_Gabriel_Viinikka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BooksDB_Gabriel_Viinikka.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20250122203504_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ISBN")
                        .HasColumnType("bigint");

                    b.Property<DateOnly>("PublicationDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.BookInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BooksInventory");
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.Loaner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LoanerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Loaners");
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.Loans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActualBookId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ActualReturnDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("LoanDate")
                        .HasColumnType("date");

                    b.Property<int>("LoanerId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReturnDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ActualBookId");

                    b.HasIndex("LoanerId");

                    b.ToTable("DbLoans");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("BooksDB_Gabriel_Viinikka.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksDB_Gabriel_Viinikka.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.BookInventory", b =>
                {
                    b.HasOne("BooksDB_Gabriel_Viinikka.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BooksDB_Gabriel_Viinikka.Models.Loans", b =>
                {
                    b.HasOne("BooksDB_Gabriel_Viinikka.Models.BookInventory", "ActualBook")
                        .WithMany()
                        .HasForeignKey("ActualBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BooksDB_Gabriel_Viinikka.Models.Loaner", "Loaner")
                        .WithMany()
                        .HasForeignKey("LoanerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActualBook");

                    b.Navigation("Loaner");
                });
#pragma warning restore 612, 618
        }
    }
}
