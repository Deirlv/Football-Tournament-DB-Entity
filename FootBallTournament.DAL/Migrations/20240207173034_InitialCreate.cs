using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootBallTournament.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictoriesCount = table.Column<int>(type: "int", nullable: false),
                    LosesCount = table.Column<int>(type: "int", nullable: false),
                    DrawGamesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Standings");
        }
    }
}
