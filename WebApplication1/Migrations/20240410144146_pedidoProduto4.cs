﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetRestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class pedidoProduto4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProduct");

            migrationBuilder.AddColumn<Guid>(
                name: "PedidoId",
                table: "Produtos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PedidoProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PedidoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_PedidoId",
                table: "PedidoProduto",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_ProdutoId",
                table: "PedidoProduto",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "PedidoProduto");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "PedidoProduct",
                columns: table => new
                {
                    PedidosId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduct", x => new { x.PedidosId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_PedidoProduct_Pedidos_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduct_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduct_ProdutosId",
                table: "PedidoProduct",
                column: "ProdutosId");
        }
    }
}
