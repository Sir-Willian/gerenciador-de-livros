using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GerenciadorDeLivros.Migrations.Emprestimo
{
    /// <inheritdoc />
    public partial class CreateEmprestimoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emprestimos",
                columns: table => new
                {
                    emprestimo_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    livro_id = table.Column<int>(type: "integer", nullable: false),
                    data_do_emprestimo = table.Column<DateOnly>(type: "date", nullable: false),
                    data_da_devolucao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimos", x => x.emprestimo_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimos");
        }
    }
}
