using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaoRecebiveisAPI.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RamosDeAtividade",
                columns: table => new
                {
                    RamoAtividadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamosDeAtividade", x => x.RamoAtividadeId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    FaturamentoMensal = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    RamoAtividadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresas_RamosDeAtividade_RamoAtividadeId",
                        column: x => x.RamoAtividadeId,
                        principalTable: "RamosDeAtividade",
                        principalColumn: "RamoAtividadeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    CarrinhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.CarrinhoId);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    NotaFiscalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    DtVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.NotaFiscalId);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensCarrinhos",
                columns: table => new
                {
                    ItemCarrinhoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoId = table.Column<int>(type: "int", nullable: false),
                    NotaFiscalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinhos", x => x.ItemCarrinhoId);
                    table.ForeignKey(
                        name: "FK_ItensCarrinhos_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "CarrinhoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCarrinhos_NotasFiscais_NotaFiscalId",
                        column: x => x.NotaFiscalId,
                        principalTable: "NotasFiscais",
                        principalColumn: "NotaFiscalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RamosDeAtividade",
                columns: new[] { "RamoAtividadeId", "Descricao" },
                values: new object[,]
                {
                    { 1, "Produtos" },
                    { 2, "Serviços" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_EmpresaId",
                table: "Carrinhos",
                column: "EmpresaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Cnpj",
                table: "Empresas",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_RamoAtividadeId",
                table: "Empresas",
                column: "RamoAtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinhos_CarrinhoId_NotaFiscalId",
                table: "ItensCarrinhos",
                columns: new[] { "CarrinhoId", "NotaFiscalId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinhos_NotaFiscalId",
                table: "ItensCarrinhos",
                column: "NotaFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_EmpresaId",
                table: "NotasFiscais",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RamosDeAtividade_Descricao",
                table: "RamosDeAtividade",
                column: "Descricao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCarrinhos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "RamosDeAtividade");
        }
    }
}
