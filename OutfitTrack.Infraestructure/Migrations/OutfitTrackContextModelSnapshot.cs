﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutfitTrack.Infraestructure;

#nullable disable

namespace OutfitTrack.Infraestructure.Migrations
{
    [DbContext(typeof(OutfitTrackContext))]
    partial class OutfitTrackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Customer", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired()
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_nascimento");

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_alteracao");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("nome_cidade");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("complemento");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("cpf");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_cadastro");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(256)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("primeiro_nome");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("sobrenome");

                    b.Property<string>("MobilePhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(13)")
                        .HasColumnName("numero_celular");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("bairro");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("numero");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .HasColumnType("VARCHAR(9)")
                        .HasColumnName("rg");

                    b.Property<string>("StateAbbreviation")
                        .IsRequired()
                        .HasColumnType("VARCHAR(2)")
                        .HasColumnName("sigla_estado");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("endereco");

                    b.HasKey("Id");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Order", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_alteracao");

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_encerramento");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_cadastro");

                    b.Property<long?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id_cliente");

                    b.Property<long?>("Number")
                        .IsRequired()
                        .HasColumnType("BIGINT")
                        .HasColumnName("numero");

                    b.Property<int>("Status")
                        .HasColumnType("INT")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("pedido", (string)null);
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_alteracao");

                    b.Property<string>("Color")
                        .HasColumnType("VARCHAR(30)")
                        .HasColumnName("cor");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_cadastro");

                    b.Property<int?>("Item")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("item");

                    b.Property<long?>("OrderId")
                        .IsRequired()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id_pedido");

                    b.Property<long?>("ProductId")
                        .IsRequired()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id_produto");

                    b.Property<string>("Size")
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("tamanho");

                    b.Property<int>("Status")
                        .HasColumnType("INT")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("pedido_item", (string)null);
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Product", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("marca");

                    b.Property<string>("Category")
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("categoria");

                    b.Property<DateTime?>("ChangeDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_alteracao");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("codigo");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("DATETIME")
                        .HasColumnName("data_cadastro");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("descricao");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("DECIMAL(10,2)")
                        .HasColumnName("preco");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("INT")
                        .HasColumnName("quantidade");

                    b.HasKey("Id");

                    b.ToTable("produto", (string)null);
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Order", b =>
                {
                    b.HasOne("OutfitTrack.Domain.Entities.Customer", "Customer")
                        .WithMany("ListOrder")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("OutfitTrack.Domain.Entities.Order", "Order")
                        .WithMany("ListOrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutfitTrack.Domain.Entities.Product", "Product")
                        .WithMany("ListOrderItem")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Customer", b =>
                {
                    b.Navigation("ListOrder");
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Order", b =>
                {
                    b.Navigation("ListOrderItem");
                });

            modelBuilder.Entity("OutfitTrack.Domain.Entities.Product", b =>
                {
                    b.Navigation("ListOrderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
