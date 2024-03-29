﻿// <auto-generated />
using System;
using CVirtual.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CVirtual.Data.Migrations
{
    [DbContext(typeof(CVContext))]
    [Migration("20200709232119_Arquivo")]
    partial class Arquivo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("Models.Classes.ArquivoRegistros", b =>
                {
                    b.Property<int>("ArquivoRegistrosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NotaContaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Registro")
                        .HasColumnType("TEXT");

                    b.HasKey("ArquivoRegistrosId");

                    b.HasIndex("NotaContaId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("Models.Classes.Atendente", b =>
                {
                    b.Property<int>("AtendenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NivelAcesso")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AtendenteId");

                    b.ToTable("Atendentes");
                });

            modelBuilder.Entity("Models.Classes.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Models.Classes.NotaConta", b =>
                {
                    b.Property<int>("NotaContaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataConta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("LimiteConta")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalConta")
                        .HasColumnType("REAL");

                    b.HasKey("NotaContaId");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("NotaContas");
                });

            modelBuilder.Entity("Models.Classes.RegistroNota", b =>
                {
                    b.Property<int>("RegistroNotaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeAtendente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NotaContaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TextoDescricao")
                        .HasColumnType("TEXT")
                        .HasMaxLength(200);

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("RegistroNotaId");

                    b.HasIndex("NotaContaId");

                    b.ToTable("RegistroNotas");
                });

            modelBuilder.Entity("Models.Classes.ArquivoRegistros", b =>
                {
                    b.HasOne("Models.Classes.NotaConta", null)
                        .WithMany("Arquivo")
                        .HasForeignKey("NotaContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Classes.NotaConta", b =>
                {
                    b.HasOne("Models.Classes.Cliente", null)
                        .WithOne("NotaConta")
                        .HasForeignKey("Models.Classes.NotaConta", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Classes.RegistroNota", b =>
                {
                    b.HasOne("Models.Classes.NotaConta", null)
                        .WithMany("RegistroNotas")
                        .HasForeignKey("NotaContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
