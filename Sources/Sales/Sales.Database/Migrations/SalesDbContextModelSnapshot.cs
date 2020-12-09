﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCompany.Crm.Sales;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyCompany.Crm.Sales.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    partial class SalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("OrderHeaderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeaderId");

                    b.ToTable("OrderNotes");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.SalesDb+Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPlaced")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("PriceAgreementExpiresOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PriceAgreementType")
                        .HasColumnType("text");

                    b.Property<uint>("xmin")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.SalesDb+OrderItem", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("AmountUnit")
                        .HasColumnType("text");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId", "ProductId", "AmountUnit");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderHeader", b =>
                {
                    b.OwnsOne("MyCompany.Crm.Sales.Orders.InvoicingDetails", "InvoicingDetails", b1 =>
                        {
                            b1.Property<Guid>("OrderHeaderId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<string>("TaxId")
                                .HasColumnType("text");

                            b1.HasKey("OrderHeaderId");

                            b1.ToTable("OrderHeaders");

                            b1.WithOwner()
                                .HasForeignKey("OrderHeaderId");
                        });
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.Orders.OrderNote", b =>
                {
                    b.HasOne("MyCompany.Crm.Sales.Orders.OrderHeader", null)
                        .WithMany("Notes")
                        .HasForeignKey("OrderHeaderId");
                });

            modelBuilder.Entity("MyCompany.Crm.Sales.SalesDb+OrderItem", b =>
                {
                    b.HasOne("MyCompany.Crm.Sales.SalesDb+Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
