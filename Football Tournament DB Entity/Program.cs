using FootBallTournament.DAL;
using Microsoft.EntityFrameworkCore;

namespace Football_Tournament_DB_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FootBallTournamentContext())
            {
                var standing = new Standing { TeamName = "FC Barcelona", TeamCity = "Barcelona", VictoriesCount = 4, LosesCount = 1, DrawGamesCount = 0, Goals = 4, GoalsMissed = 2};
                context.Standings.Add(standing);
                standing = new Standing { TeamName = "Manchester United F.C.", TeamCity = "Manchester", VictoriesCount = 2, LosesCount = 2, DrawGamesCount = 1, Goals = 2, GoalsMissed = 6};
                context.Standings.Add(standing);
                context.SaveChanges();
            }

            using (var context = new FootBallTournamentContext())
            {
                foreach (var info in context.Standings)
                {
                    Console.WriteLine($"Team: {info.TeamName}, City: {info.TeamCity}, Wins: {info.VictoriesCount}, Loses: {info.LosesCount}, Draws: {info.DrawGamesCount}, Goals: {info.Goals}, Goals Missed: {info.GoalsMissed}");
                }
            }
        }
    }
}
