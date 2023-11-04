using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EeFee.Migrations
{
    public partial class fgdsafg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_user",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_position",
                newName: "position_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "tb_user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "position_id",
                table: "tb_position",
                newName: "id");
        }
    }
}
