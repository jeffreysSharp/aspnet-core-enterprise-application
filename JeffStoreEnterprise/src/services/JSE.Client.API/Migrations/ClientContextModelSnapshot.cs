﻿// <auto-generated />
using System;
using JSE.Catalogo.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JSE.Client.API.Migrations
{
    [DbContext(typeof(ClientContext))]
    partial class ClientContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JSE.Client.API.Models.ClientAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AddressType")
                        .HasColumnType("int");

                    b.Property<string>("Addresss")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IsDefaultAddress")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientAddresses", (string)null);
                });

            modelBuilder.Entity("JSE.Client.API.Models.ClientPurchaseHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientPurchaseHistories", (string)null);
                });

            modelBuilder.Entity("JSE.Client.API.Models.Clients", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthdayDate")
                        .HasColumnType("Date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsRemoved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("JSE.Client.API.Models.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genders", (string)null);
                });

            modelBuilder.Entity("JSE.Client.API.Models.ClientAddress", b =>
                {
                    b.HasOne("JSE.Client.API.Models.Clients", "Client")
                        .WithMany("Addresses")
                        .HasForeignKey("ClientId")
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("JSE.Client.API.Models.ClientPurchaseHistory", b =>
                {
                    b.HasOne("JSE.Client.API.Models.Clients", "Client")
                        .WithMany("PurchaseHistories")
                        .HasForeignKey("ClientId")
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("JSE.Client.API.Models.Clients", b =>
                {
                    b.HasOne("JSE.Client.API.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .IsRequired();

                    b.OwnsOne("JSE.Core.DomainObjects.ClientDocument", "DocumentNumber", b1 =>
                        {
                            b1.Property<Guid>("ClientsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DocumentNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(11)")
                                .HasColumnName("DocumentNumber");

                            b1.HasKey("ClientsId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientsId");
                        });

                    b.OwnsOne("JSE.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClientsId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EmailAddress")
                                .IsRequired()
                                .HasColumnType("varchar(254)")
                                .HasColumnName("EmailAddress");

                            b1.HasKey("ClientsId");

                            b1.ToTable("Clients");

                            b1.WithOwner()
                                .HasForeignKey("ClientsId");
                        });

                    b.Navigation("DocumentNumber")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("JSE.Client.API.Models.Clients", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("PurchaseHistories");
                });
#pragma warning restore 612, 618
        }
    }
}