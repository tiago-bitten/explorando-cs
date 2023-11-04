using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EeFee.Migrations
{
    public partial class PositionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_position_PositionId",
                table: "tb_user");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "tb_user",
                newName: "position_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_PositionId",
                table: "tb_user",
                newName: "IX_tb_user_position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_position_position_id",
                table: "tb_user",
                column: "position_id",
                principalTable: "tb_position",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_position_position_id",
                table: "tb_user");

            migrationBuilder.RenameColumn(
                name: "position_id",
                table: "tb_user",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_position_id",
                table: "tb_user",
                newName: "IX_tb_user_PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_position_PositionId",
                table: "tb_user",
                column: "PositionId",
                principalTable: "tb_position",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
