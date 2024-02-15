using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootBallTournament.DAL.Migrations
{
    public partial class MatchesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StandingId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_StandingId",
                table: "Matches",
                column: "StandingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Standings_StandingId",
                table: "Matches",
                column: "StandingId",
                principalTable: "Standings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Standings_StandingId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_StandingId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "StandingId",
                table: "Matches");
        }
    }
}
