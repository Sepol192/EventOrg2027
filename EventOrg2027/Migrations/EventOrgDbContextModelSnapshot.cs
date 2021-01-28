﻿// <auto-generated />
using System;
using EventOrg2027.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventOrg2027.Migrations
{
    [DbContext(typeof(EventOrgDbContext))]
    partial class EventOrgDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventOrg2027.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("EventOrg2027.Models.Eventos", b =>
                {
                    b.Property<int>("EventosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataRealizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(3000)")
                        .HasMaxLength(3000);

                    b.Property<DateTime>("HoraRealizacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalidadeId")
                        .HasColumnType("int");

                    b.Property<int>("Lotacao")
                        .HasColumnType("int");

                    b.Property<string>("NomeEventos")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OrganizadorId")
                        .HasColumnType("int");

                    b.Property<int>("TipoEventosId")
                        .HasColumnType("int");

                    b.HasKey("EventosId");

                    b.HasIndex("LocalidadeId");

                    b.HasIndex("OrganizadorId");

                    b.HasIndex("TipoEventosId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EventOrg2027.Models.Inscricao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventoID")
                        .HasColumnType("int");

                    b.Property<int?>("EventosId")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EventosId");

                    b.ToTable("Inscricao");
                });

            modelBuilder.Entity("EventOrg2027.Models.Localidade", b =>
                {
                    b.Property<int>("LocalidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("NomeLocalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Populacao")
                        .HasColumnType("int");

                    b.HasKey("LocalidadeId");

                    b.ToTable("Localidade");
                });

            modelBuilder.Entity("EventOrg2027.Models.Organizador", b =>
                {
                    b.Property<int>("OrganizadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeOrganizador")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("OrganizadorId");

                    b.ToTable("Organizador");
                });

            modelBuilder.Entity("EventOrg2027.Models.TipoEventos", b =>
                {
                    b.Property<int>("TipoEventosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeTipoEventos")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TipoEventosId");

                    b.ToTable("TiposEventos");
                });

            modelBuilder.Entity("EventOrg2027.Models.Eventos", b =>
                {
                    b.HasOne("EventOrg2027.Models.Localidade", "Localidade")
                        .WithMany()
                        .HasForeignKey("LocalidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventOrg2027.Models.Organizador", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventOrg2027.Models.TipoEventos", "TipoEventos")
                        .WithMany()
                        .HasForeignKey("TipoEventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventOrg2027.Models.Inscricao", b =>
                {
                    b.HasOne("EventOrg2027.Models.Eventos", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventosId");
                });
#pragma warning restore 612, 618
        }
    }
}
