using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace abantu.mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Funcionarios_FuncionarioId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_FuncionarioId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Avaliacoes");

            migrationBuilder.RenameColumn(
                name: "Demissao",
                table: "Funcionarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "IdGerente",
                table: "Avaliacoes",
                newName: "AvaliadorId");

            migrationBuilder.RenameColumn(
                name: "IdFuncionario",
                table: "Avaliacoes",
                newName: "AvaliadoId");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_AvaliadoId",
                table: "Avaliacoes",
                column: "AvaliadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_AvaliadorId",
                table: "Avaliacoes",
                column: "AvaliadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Funcionarios_AvaliadoId",
                table: "Avaliacoes",
                column: "AvaliadoId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Funcionarios_AvaliadorId",
                table: "Avaliacoes",
                column: "AvaliadorId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Funcionarios_AvaliadoId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Funcionarios_AvaliadorId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_AvaliadoId",
                table: "Avaliacoes");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_AvaliadorId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Funcionarios",
                newName: "Demissao");

            migrationBuilder.RenameColumn(
                name: "AvaliadorId",
                table: "Avaliacoes",
                newName: "IdGerente");

            migrationBuilder.RenameColumn(
                name: "AvaliadoId",
                table: "Avaliacoes",
                newName: "IdFuncionario");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Avaliacoes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_FuncionarioId",
                table: "Avaliacoes",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Funcionarios_FuncionarioId",
                table: "Avaliacoes",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id");
        }
    }
}
