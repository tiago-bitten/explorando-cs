using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EeFee.Migrations
{
    public partial class fdsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_position_position_id",
                table: "tb_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_position",
                table: "tb_position");

            migrationBuilder.RenameTable(
                name: "tb_user",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tb_position",
                newName: "Positions");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "position_id",
                table: "Users",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_position_id",
                table: "Users",
                newName: "IX_Users_PositionId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Positions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "position_id",
                table: "Positions",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Positions_PositionId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "tb_user");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "tb_position");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "tb_user",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tb_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "tb_user",
                newName: "position_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_user",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_PositionId",
                table: "tb_user",
                newName: "IX_tb_user_position_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_position",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_position",
                newName: "position_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_position",
                table: "tb_position",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_position_position_id",
                table: "tb_user",
                column: "position_id",
                principalTable: "tb_position",
                principalColumn: "position_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
