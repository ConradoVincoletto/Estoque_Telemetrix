using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InfraEstrutura.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    CATEGORIA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CATEGORIA_NOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CATEGORIA_CONTROLA_ESTOQUE = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CATEGORIA_MAXIMO_ITENS = table.Column<int>(type: "int", nullable: false),
                    CATEGORIA_DATA_CRIACAO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CATEGORIA_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.CATEGORIA_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    PRODUTO_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PRODUTO_NOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    categoriaId = table.Column<int>(type: "int", nullable: false),
                    PRODUTO_QUANTIDADE = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PRODUTO_DATA_CRIAÇÃO = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PRODUTO_ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.PRODUTO_ID);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_CATEGORIA_categoriaId",
                        column: x => x.categoriaId,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "CATEGORIA_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_categoriaId",
                table: "TB_PRODUTO",
                column: "categoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");
        }
    }
}
