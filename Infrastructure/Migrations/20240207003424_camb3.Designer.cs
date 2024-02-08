﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240207003424_camb3")]
    partial class camb3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entidades.Objetos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(270)
                        .HasColumnType("character varying(270)");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("valor")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("ObjetoGG", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Personaje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("HP")
                        .HasColumnType("integer");

                    b.Property<int>("MP")
                        .HasColumnType("integer");

                    b.Property<int>("defensa")
                        .HasColumnType("integer");

                    b.Property<int>("estamina")
                        .HasColumnType("integer");

                    b.Property<double>("experiencia")
                        .HasColumnType("double precision");

                    b.Property<int>("fuerza")
                        .HasColumnType("integer");

                    b.Property<int>("inteligencia")
                        .HasColumnType("integer");

                    b.Property<int>("nivel")
                        .HasColumnType("integer");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(270)
                        .HasColumnType("character varying(270)");

                    b.Property<int>("resistencia")
                        .HasColumnType("integer");

                    b.Property<int>("tipoId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("tipoId");

                    b.ToTable("PersonajeGG", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Core.Entidades.Recompensa", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("experiencia")
                        .HasColumnType("integer");

                    b.Property<int>("monedas")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("RecompensaGG", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.TipoPersonaje", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(270)
                        .HasColumnType("character varying(270)");

                    b.HasKey("id");

                    b.ToTable("TipoPersonajeGG", (string)null);
                });

            modelBuilder.Entity("ObjetosRecompensa", b =>
                {
                    b.Property<int>("Recompensasid")
                        .HasColumnType("integer");

                    b.Property<int>("objetosid")
                        .HasColumnType("integer");

                    b.HasKey("Recompensasid", "objetosid");

                    b.HasIndex("objetosid");

                    b.ToTable("ObjetosRecompensa");
                });

            modelBuilder.Entity("Core.Entidades.Enemigo", b =>
                {
                    b.HasBaseType("Core.Entidades.Personaje");

                    b.Property<int?>("TipoPersonajeid")
                        .HasColumnType("integer");

                    b.Property<int>("recompensaId")
                        .HasColumnType("integer");

                    b.HasIndex("TipoPersonajeid");

                    b.HasIndex("recompensaId");

                    b.ToTable("EnemigoGG", (string)null);
                });

            modelBuilder.Entity("Core.Entidades.Personaje", b =>
                {
                    b.HasOne("Core.Entidades.TipoPersonaje", "tipo")
                        .WithMany("Personajes")
                        .HasForeignKey("tipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tipo");
                });

            modelBuilder.Entity("ObjetosRecompensa", b =>
                {
                    b.HasOne("Core.Entidades.Recompensa", null)
                        .WithMany()
                        .HasForeignKey("Recompensasid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Objetos", null)
                        .WithMany()
                        .HasForeignKey("objetosid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entidades.Enemigo", b =>
                {
                    b.HasOne("Core.Entidades.TipoPersonaje", null)
                        .WithMany("Enemigos")
                        .HasForeignKey("TipoPersonajeid");

                    b.HasOne("Core.Entidades.Personaje", null)
                        .WithOne()
                        .HasForeignKey("Core.Entidades.Enemigo", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entidades.Recompensa", "Recompensa")
                        .WithMany("enemigos")
                        .HasForeignKey("recompensaId");

                    b.Navigation("Recompensa");
                });

            modelBuilder.Entity("Core.Entidades.Recompensa", b =>
                {
                    b.Navigation("enemigos");
                });

            modelBuilder.Entity("Core.Entidades.TipoPersonaje", b =>
                {
                    b.Navigation("Enemigos");

                    b.Navigation("Personajes");
                });
#pragma warning restore 612, 618
        }
    }
}