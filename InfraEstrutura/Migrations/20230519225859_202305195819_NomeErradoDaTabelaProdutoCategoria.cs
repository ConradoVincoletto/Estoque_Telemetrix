using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class _202305195819_NomeErradoDaTabelaProdutoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRODUTO_CATEGORA",
                table: "TB_PRODUTO",
                newName: "PRODUTO_CATEGORIA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRODUTO_CATEGORIA",
                table: "TB_PRODUTO",
                newName: "PRODUTO_CATEGORA");
        }
    }
}
