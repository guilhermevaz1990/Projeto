﻿// <auto-generated />
using System;
using Evt.Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Evt.Test.Data.Migrations
{
    [DbContext(typeof(EvtContext))]
    [Migration("20200112180051_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("Evt.Test.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Evt.Test.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Evt.Test.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Evt.Test.Model.Order", b =>
                {
                    b.HasOne("Evt.Test.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Evt.Test.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
