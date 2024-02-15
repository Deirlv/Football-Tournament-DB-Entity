using DictionaryApp;
using FootBallTournament.DAL;
using FootBallTournament.DAL.Entities;
using FootBallTournament.DAL.Service;
using FootBallTournament.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Football_Tournament_DB_Entity.App;

namespace Football_Tournament_DB_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var standingsService = new StandingsService();
            

            while (true)
            {
                Console.Clear();
                int start_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Edit", "Custom Search", "Default Search");
                Console.Clear();
                switch (start_menu_index)
                {
                    case 0: App.App.Edit(standingsService); break;
                        
                        

                    case 1:
                        {
                            int custom_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Search by name", "Search by city", "Search by name and city", "Back");
                            Console.Clear();
                            switch (custom_queries_index)
                            {
                                case 0:
                                    {
                                        Console.SetCursorPosition(30, 7);
                                        Console.Write("Enter the team's name: ");
                                        string? team_name = Console.ReadLine();
                                        Standing? standing = standingsService.FindStandingName(team_name);
                                        if(standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.SetCursorPosition(30, 8);
                                        Console.Write("Enter the team's city: ");
                                        string? team_city = Console.ReadLine();
                                        Standing? standing = standingsService.FindStandingCity(team_city);
                                        if (standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.SetCursorPosition(30, 7);
                                        Console.Write("Enter the team's name: ");
                                        string? team_name = Console.ReadLine();

                                        Console.SetCursorPosition(30, 8);
                                        Console.Write("Enter the team's city: ");
                                        string? team_city = Console.ReadLine();

                                        Standing? standing = standingsService.FindStanding(team_name, team_city);

                                        if (standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 3:
                                    {

                                        continue;
                                    }
                            }
                            break;
                        }

                    case 2:
                        {
                            int default_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "All", "The most victories", "The most loses", "The most draws", "The most goals", "The most goals missed", "Back");
                            Console.Clear();
                            switch (default_queries_index)
                            {
                                case 0:
                                    {
                                        foreach(var standing in standingsService.GetAllStandings())
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                        }
                                        Console.ReadKey();
                                        break;
                                    }
                                case 1:
                                    {
                                        Standing? standing = standingsService.GetTeamMostVictories();
                                        if(standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Standing? standing = standingsService.GetTeamMostLoses();
                                        if (standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Standing? standing = standingsService.GetTeamMostDrawGames();
                                        if (standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        Standing? standing = standingsService.GetTeamMostGoalsScored();
                                        if (standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 5:
                                    {
                                        Standing? standing = standingsService.GetTeamMostGoalsMissed();
                                        if (standing != null)
                                        {
                                            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                        break;
                                    }
                                case 6:
                                    {
                                        continue;
                                    }
                            }
                            break;
                        }
                        
                }
            }
        }
    }
}
