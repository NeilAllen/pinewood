﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pinewood.api;

#nullable disable

namespace pinewood.api.Migrations
{
    [DbContext(typeof(CustomerDb))]
    [Migration("20241021081139_customer.createdat")]
    partial class customercreatedat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("pinewood.shared.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelephoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 10, 21, 9, 11, 39, 266, DateTimeKind.Local).AddTicks(1460),
                            EmailAddress = "First Customer EmailAddress",
                            Name = "First Customer Name",
                            PostalAddress = "First Customer PostalAddress",
                            PostalCode = "First Customer PostalCode",
                            TelephoneNumber = "First Customer TelephoneNumber"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 10, 21, 9, 11, 39, 266, DateTimeKind.Local).AddTicks(1500),
                            EmailAddress = "Second Customer EmailAddress",
                            Name = "Second Customer Name",
                            PostalAddress = "Second Customer PostalAddress",
                            PostalCode = "Second Customer PostalCode",
                            TelephoneNumber = "Second Customer TelephoneNumber"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
