using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoTypingTest.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_score",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    wpm = table.Column<double>(type: "double precision", nullable: false),
                    accuracy = table.Column<double>(type: "double precision", nullable: false),
                    test_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_score", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_score_tb_test_test_id",
                        column: x => x.test_id,
                        principalTable: "tb_test",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_score_test_id",
                table: "tb_score",
                column: "test_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_score");
        }
    }
}
