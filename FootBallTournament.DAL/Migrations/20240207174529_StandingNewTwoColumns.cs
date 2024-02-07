using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootBallTournament.DAL.Migrations
{
    public partial class StandingNewTwoColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Standings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalsMissed",
                table: "Standings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Goals",
                table: "Standings");

            migrationBuilder.DropColumn(
                name: "GoalsMissed",
                table: "Standings");
        }
    }
}
