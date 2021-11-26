﻿// <auto-generated />
using System;
using ConexionBD.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConexionBD.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211126042319_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectSerInfo.Dominio.EvidenciaPC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquiposId")
                        .HasColumnType("int");

                    b.Property<int>("Fallas")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EquiposId");

                    b.ToTable("EvidenciaPCs");
                });

            modelBuilder.Entity("ProyectSerInfo.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("ProyectSerInfo.Dominio.Equipos", b =>
                {
                    b.HasBaseType("ProyectSerInfo.Dominio.Persona");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TecnicoId")
                        .HasColumnType("int");

                    b.HasIndex("TecnicoId");

                    b.HasDiscriminator().HasValue("Equipos");
                });

            modelBuilder.Entity("ProyectSerInfo.Dominio.Tecnico", b =>
                {
                    b.HasBaseType("ProyectSerInfo.Dominio.Persona");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistroRethus")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Tecnico");
                });

            modelBuilder.Entity("ProyectSerInfo.Dominio.EvidenciaPC", b =>
                {
                    b.HasOne("ProyectSerInfo.Dominio.Equipos", "Equipos")
                        .WithMany()
                        .HasForeignKey("EquiposId");

                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("ProyectSerInfo.Dominio.Equipos", b =>
                {
                    b.HasOne("ProyectSerInfo.Dominio.Tecnico", "Tecnico")
                        .WithMany()
                        .HasForeignKey("TecnicoId");

                    b.Navigation("Tecnico");
                });
#pragma warning restore 612, 618
        }
    }
}
