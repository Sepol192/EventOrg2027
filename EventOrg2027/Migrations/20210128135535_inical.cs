﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventOrg2027.Migrations
{
    public partial class inical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Localidade",
                columns: table => new
                {
                    LocalidadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLocalidade = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 200, nullable: false),
                    Populacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidade", x => x.LocalidadeId);
                });

            migrationBuilder.CreateTable(
                name: "Organizador",
                columns: table => new
                {
                    OrganizadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOrganizador = table.Column<string>(maxLength: 50, nullable: false),
                    Contacto = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizador", x => x.OrganizadorId);
                });

            migrationBuilder.CreateTable(
                name: "TiposEventos",
                columns: table => new
                {
                    TipoEventosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoEventos = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEventos", x => x.TipoEventosId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEventos = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(maxLength: 3000, nullable: false),
                    Lotacao = table.Column<int>(nullable: false),
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    HoraRealizacao = table.Column<DateTime>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: false),
                    TipoEventosId = table.Column<int>(nullable: false),
                    OrganizadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventosId);
                    table.ForeignKey(
                        name: "FK_Eventos_Localidade_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidade",
                        principalColumn: "LocalidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_Organizador_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizador",
                        principalColumn: "OrganizadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Eventos_TiposEventos_TipoEventosId",
                        column: x => x.TipoEventosId,
                        principalTable: "TiposEventos",
                        principalColumn: "TipoEventosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscricao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInscricao = table.Column<DateTime>(nullable: false),
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    HoraRealizacao = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: true),
                    EventoID = table.Column<int>(nullable: false),
                    EventoNome = table.Column<string>(nullable: true),
                    EventosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inscricao_Eventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "Eventos",
                        principalColumn: "EventosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalidadeId",
                table: "Eventos",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_OrganizadorId",
                table: "Eventos",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventosId",
                table: "Eventos",
                column: "TipoEventosId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricao_EventosId",
                table: "Inscricao",
                column: "EventosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Inscricao");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Localidade");

            migrationBuilder.DropTable(
                name: "Organizador");

            migrationBuilder.DropTable(
                name: "TiposEventos");
        }
    }
}
