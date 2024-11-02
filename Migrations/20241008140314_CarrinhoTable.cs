using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Servicos_ServicosId",
                table: "Carrinho");

            migrationBuilder.RenameColumn(
                name: "ServicosId",
                table: "Carrinho",
                newName: "ServicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinho_ServicosId",
                table: "Carrinho",
                newName: "IX_Carrinho_ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Servicos_ServicoId",
                table: "Carrinho",
                column: "ServicoId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Servicos_ServicoId",
                table: "Carrinho");

            migrationBuilder.RenameColumn(
                name: "ServicoId",
                table: "Carrinho",
                newName: "ServicosId");

            migrationBuilder.RenameIndex(
                name: "IX_Carrinho_ServicoId",
                table: "Carrinho",
                newName: "IX_Carrinho_ServicosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Servicos_ServicosId",
                table: "Carrinho",
                column: "ServicosId",
                principalTable: "Servicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
