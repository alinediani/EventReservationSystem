using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventReservationSystem.Migrations
{
    /// <inheritdoc />
    public partial class AttModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reservas",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Reservas",
                newName: "ReservaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Eventos",
                newName: "EventoId");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Reservas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Reservas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCancelamento",
                table: "Reservas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DataCancelamento",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Reservas",
                newName: "DataReserva");

            migrationBuilder.RenameColumn(
                name: "ReservaId",
                table: "Reservas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EventoId",
                table: "Eventos",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Usuarios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Reservas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Usuarios_UsuarioId",
                table: "Reservas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
