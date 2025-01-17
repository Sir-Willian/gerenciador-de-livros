using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciadorDeLivros.Migrations.Emprestimo
{
    /// <inheritdoc />
    public partial class ForeignKeyFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_emprestimos_livro_id",
                table: "emprestimos",
                column: "livro_id");

            migrationBuilder.AddForeignKey(
                name: "FK_emprestimos_livros_livro_id",
                table: "emprestimos",
                column: "livro_id",
                principalTable: "livros",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emprestimos_livros_livro_id",
                table: "emprestimos");

            migrationBuilder.DropIndex(
                name: "IX_emprestimos_livro_id",
                table: "emprestimos");
        }
    }
}
