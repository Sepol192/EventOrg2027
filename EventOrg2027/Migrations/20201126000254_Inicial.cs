﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventOrg2027.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEventos = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(maxLength: 100, nullable: false),
                    HoraInicio = table.Column<string>(nullable: true),
                    Lotacao = table.Column<string>(nullable: true),
                    DataRealizacao = table.Column<DateTime>(nullable: false),
                    LocalidadeId = table.Column<int>(nullable: true),
                    TipoEventosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventosId);
                    table.ForeignKey(
                        name: "FK_Eventos_Localidade_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Localidade",
                        principalColumn: "LocalidadeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_TiposEventos_TipoEventosId",
                        column: x => x.TipoEventosId,
                        principalTable: "TiposEventos",
                        principalColumn: "TipoEventosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalidadeId",
                table: "Eventos",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoEventosId",
                table: "Eventos",
                column: "TipoEventosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
