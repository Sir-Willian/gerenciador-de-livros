﻿// <auto-generated />
using System;
using GerenciadorDeLivros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciadorDeLivros.Migrations
{
    [DbContext(typeof(LivroContext))]
    partial class LivroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GerenciadorDeLivros.Model.Livro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("autor");

                    b.Property<int>("Classificacao")
                        .HasColumnType("integer")
                        .HasColumnName("classificacao");

                    b.Property<DateOnly>("DataDePublicacao")
                        .HasColumnType("date")
                        .HasColumnName("data_de_publicacao");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("genero");

                    b.Property<string>("Resumo")
                        .HasColumnType("text")
                        .HasColumnName("resumo");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("livros", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
