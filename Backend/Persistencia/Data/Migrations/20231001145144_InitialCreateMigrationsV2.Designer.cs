﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

#nullable disable

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(WebDbAppiContext))]
    [Migration("20231001145144_InitialCreateMigrationsV2")]
    partial class InitialCreateMigrationsV2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.UploadResult", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("StoredFileName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.HasKey("IdCodigo");

                    b.ToTable("UploadResults", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Property<int>("IdCodigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("IdCodigo");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Dominio.Entities.UsuariosRoles", b =>
                {
                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("UsuariosRoles");
                });

            modelBuilder.Entity("Dominio.Entities.UsuariosRoles", b =>
                {
                    b.HasOne("Dominio.Entities.Rol", "Rol")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Entities.Usuario", "Usuario")
                        .WithMany("UsuariosRoles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Dominio.Entities.Rol", b =>
                {
                    b.Navigation("UsuariosRoles");
                });

            modelBuilder.Entity("Dominio.Entities.Usuario", b =>
                {
                    b.Navigation("UsuariosRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
