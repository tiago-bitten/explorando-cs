using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EeFee.Migrations
{
    public partial class MigracaoCerta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_position_tb_user_UserId",
                table: "tb_position");

            migrationBuilder.DropIndex(
                name: "IX_tb_position_UserId",
                table: "tb_position");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tb_position");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_PositionId",
                table: "tb_user",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_position_PositionId",
                table: "tb_user",
                column: "PositionId",
                principalTable: "tb_position",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_position_PositionId",
                table: "tb_user");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_PositionId",
                table: "tb_user");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tb_position",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_position_UserId",
                table: "tb_position",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_position_tb_user_UserId",
                table: "tb_position",
                column: "UserId",
                principalTable: "tb_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
