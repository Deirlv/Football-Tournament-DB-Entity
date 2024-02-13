﻿using DictionaryApp;
using FootBallTournament.DAL;
using FootBallTournament.DAL.Entities;
using FootBallTournament.DAL.Service;
using FootBallTournament.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Football_Tournament_DB_Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var standingsService = new StandingsService(new FootBallTournamentContext());
            

            while (true)
            {
                Console.Clear();
                int start_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Edit", "Custom Search", "Default Search");
                Console.Clear();
                switch (start_menu_index)
                {
                    case 0:
                        
                        int edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Add Team", "Edit Team", "Delete Team", "Back");
                        Console.Clear();
                        switch (edit_menu_index)
                        {

                            case 0:
                                {
                                    Console.Clear();

                                    Console.SetCursorPosition(30, 7);
                                    Console.Write("Team's name: ");
                                    string? team_name = Console.ReadLine();

                                    Console.SetCursorPosition(30, 8);
                                    Console.Write("Team's city: ");
                                    string? team_city = Console.ReadLine();

                                    Console.SetCursorPosition(30, 9);
                                    Console.Write("Count of victories: ");
                                    int victories_count = int.Parse(Console.ReadLine());

                                    Console.SetCursorPosition(30, 10);
                                    Console.Write("Count of loses: ");
                                    int loses_count = int.Parse(Console.ReadLine());

                                    Console.SetCursorPosition(30, 11);
                                    Console.Write("Count of draws: ");
                                    int draw_games_count = int.Parse(Console.ReadLine());

                                    Console.SetCursorPosition(30, 12);
                                    Console.Write("Count of goals: ");
                                    int goals = int.Parse(Console.ReadLine());

                                    Console.SetCursorPosition(30, 13);
                                    Console.Write("Count of goals missed: ");
                                    int goals_missed = int.Parse(Console.ReadLine());

                                    using (var context = new FootBallTournamentContext())
                                    {
                                        Standing? unique_standing = standingsService.UniqueFill(team_name, team_city, victories_count, loses_count, draw_games_count, goals, goals_missed);

                                        if (unique_standing != null)
                                        {
                                            context.Standings.Add(unique_standing);
                                            context.SaveChanges();
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(30, 14);
                                            Console.WriteLine("There is already a team with the same name.");
                                            Console.ReadKey();
                                            continue;
                                        }
                                    }

                                    break;
                                }
                                

                            case 1:
                                {

                                    Console.SetCursorPosition(30, 7);
                                    Console.Write("Enter the team's name: ");
                                    string? team_name = Console.ReadLine();

                                    Console.SetCursorPosition(30, 8);
                                    Console.Write("Enter the team's city: ");
                                    string? team_city = Console.ReadLine();

                                    using (var context = new FootBallTournamentContext())
                                    {
                                        Standing? found_standing = standingsService.FindStanding(team_name, team_city);
                                        if(found_standing != null)
                                        {
                                            Console.Clear();

                                            Console.SetCursorPosition(30, 7);
                                            Console.WriteLine("Enter what do you want to edit: ");
                                            int process_edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, 
                                                "Team's name", "Team's city", "Count of victories", "Count of loses", "Count of draws", "Count of goals", "Count of goals missed");
                                            switch (process_edit_menu_index)
                                            {
                                                case 0:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.Write("Enter the new team's name: ");
                                                        team_name = Console.ReadLine();

                                                        if (found_standing.TeamName == team_name)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.TeamName = team_name;
                                                            bool is_unique = standingsService.IsUnique(found_standing);
                                                            if(is_unique)
                                                            {
                                                                standingsService.UpdateStanding(found_standing);
                                                                context.SaveChanges();
                                                            }
                                                            else
                                                            {
                                                                Console.SetCursorPosition(30, 8);
                                                                Console.WriteLine("There is already a team with the same name.");
                                                                Console.ReadKey();
                                                            }
                                                            continue;
                                                        }
                                                    }
                                                case 1:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.Write("Enter the new team's city: ");
                                                        team_city = Console.ReadLine();
                                                        if (found_standing.TeamCity == team_city)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.TeamCity = team_city;
                                                            standingsService.UpdateStanding(found_standing);
                                                            context.SaveChanges();
                                                            continue;
                                                        }
                                                    }
                                                case 2:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.Write("Enter the new count of victories: ");
                                                        int victories = int.Parse(Console.ReadLine());
                                                        if (found_standing.VictoriesCount == victories)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.VictoriesCount = victories;
                                                            standingsService.UpdateStanding(found_standing);
                                                            context.SaveChanges();
                                                            continue;
                                                        }
                                                    }
                                                case 3:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.Write("Enter the new count of loses: ");
                                                        int loses = int.Parse(Console.ReadLine());
                                                        if (found_standing.LosesCount == loses)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.LosesCount = loses;
                                                            standingsService.UpdateStanding(found_standing);
                                                            context.SaveChanges();
                                                            continue;
                                                        }
                                                    }
                                                case 4:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.WriteLine("Enter the new count of draws: ");
                                                        int draws = int.Parse(Console.ReadLine());
                                                        if (found_standing.DrawGamesCount == draws)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.DrawGamesCount = draws;
                                                            standingsService.UpdateStanding(found_standing);
                                                            context.SaveChanges();
                                                            continue;
                                                        }
                                                    }
                                                case 5:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.Write("Enter the new count of goals: ");
                                                        int goals = int.Parse(Console.ReadLine());
                                                        if (found_standing.Goals == goals)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.Goals = goals;
                                                            standingsService.UpdateStanding(found_standing);
                                                            context.SaveChanges();
                                                            continue;
                                                        }
                                                    }
                                                case 6:
                                                    {
                                                        Console.SetCursorPosition(30, 7);
                                                        Console.Write("Enter the new count of goals missed: ");
                                                        int goals_missed = int.Parse(Console.ReadLine());
                                                        if (found_standing.GoalsMissed == goals_missed)
                                                        {
                                                            continue;
                                                        }
                                                        else
                                                        {
                                                            found_standing.GoalsMissed = goals_missed;
                                                            standingsService.UpdateStanding(found_standing);
                                                            context.SaveChanges();
                                                            continue;
                                                        }
                                                    }
                                            }

                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(30, 9);
                                            Console.WriteLine("There are no teams with this name.");
                                            Console.ReadKey();
                                            continue;
                                        }
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

                                    using (var context = new FootBallTournamentContext())
                                    {
                                        Standing? found_standing = standingsService.FindStanding(team_name, team_city);
                                        if (found_standing != null)
                                        {
                                            Console.SetCursorPosition(15, 9);
                                            Console.WriteLine($"Are you sure you want delete \"{found_standing.TeamName}\"?");
                                            int delete_agreement_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Yes", "No");
                                            switch (delete_agreement_index)
                                            {
                                                case 0:
                                                    {
                                                        standingsService.RemoveStanding(found_standing);
                                                        context.SaveChanges();
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        continue;
                                                    }
                                            }
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(30, 9);
                                            Console.WriteLine("There are no teams with this name.");
                                            Console.ReadKey();
                                            continue;
                                        }
                                    }

                                    break;
                                }

                            case 3:
                                {
                                    continue;
                                }
                        }
                        break;

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
