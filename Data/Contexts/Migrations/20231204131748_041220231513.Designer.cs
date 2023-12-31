﻿// <auto-generated />
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231204131748_041220231513")]
    partial class _041220231513
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Core.Data.Domain.Static.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Inactive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Core.Data.Domain.Static.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Inactive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Card", (string)null);
                });

            modelBuilder.Entity("Core.Data.Domain.Static.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Inactive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
