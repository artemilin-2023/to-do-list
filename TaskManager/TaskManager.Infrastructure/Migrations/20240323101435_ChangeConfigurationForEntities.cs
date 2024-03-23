using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConfigurationForEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Board_BoardId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Boards_BoardEntityId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropIndex(
                name: "IX_Issues_BoardEntityId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "BoardEntityId",
                table: "Issues");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Boards_BoardId",
                table: "Issues",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Boards_BoardId",
                table: "Issues");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardEntityId",
                table: "Issues",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_BoardEntityId",
                table: "Issues",
                column: "BoardEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Board_BoardId",
                table: "Issues",
                column: "BoardId",
                principalTable: "Board",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Boards_BoardEntityId",
                table: "Issues",
                column: "BoardEntityId",
                principalTable: "Boards",
                principalColumn: "Id");
        }
    }
}
