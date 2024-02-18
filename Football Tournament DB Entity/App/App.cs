using DictionaryApp;
using FootBallTournament.DAL.Entities;
using FootBallTournament.DAL.Service;
using FootBallTournament.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Football_Tournament_DB_Entity.App
{
    public static class App
    {
        public static void Edit(StandingsService standingsService)
        {
            int category_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Teams", "Matches", "Players", "Back");
            Console.Clear();
            if (category_menu_index == 0)
            {
                int edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Add Team", "Edit Team", "Delete Team", "Back");
                Console.Clear();
                if (edit_menu_index == 0)
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

                    Standing? unique_standing = standingsService.UniqueFill(team_name, team_city, victories_count, loses_count, draw_games_count, goals, goals_missed);

                    if (unique_standing != null)
                    {
                        standingsService.AddStanding(unique_standing);
                    }
                    else
                    {
                        Console.SetCursorPosition(30, 14);
                        Console.WriteLine("There is already a team with the same name.");
                        Console.ReadKey();
                    }

                }
                else if (edit_menu_index == 1)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Enter the team's name: ");
                    string? team_name = Console.ReadLine();

                    Console.SetCursorPosition(30, 8);
                    Console.Write("Enter the team's city: ");
                    string? team_city = Console.ReadLine();

                    Standing? found_standing = standingsService.FindStanding(team_name, team_city);
                    if (found_standing != null)
                    {
                        Console.Clear();

                        Console.SetCursorPosition(30, 7);
                        Console.WriteLine("Enter what do you want to edit: ");
                        int process_edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center,
                            "Team's name", "Team's city", "Count of victories", "Count of loses", "Count of draws", "Count of goals", "Count of goals missed");
                        if (process_edit_menu_index == 0)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.Write("Enter the new team's name: ");
                            team_name = Console.ReadLine();

                            if (found_standing.TeamName != team_name)
                            {
                                found_standing.TeamName = team_name;
                                bool is_unique = standingsService.IsUnique(found_standing);
                                if (is_unique)
                                {
                                    standingsService.Update(found_standing);
                                }
                                else
                                {
                                    Console.SetCursorPosition(30, 8);
                                    Console.WriteLine("There is already a team with the same name.");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else if (process_edit_menu_index == 1)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.Write("Enter the new team's city: ");
                            team_city = Console.ReadLine();
                            if (found_standing.TeamCity != team_city)
                            {
                                found_standing.TeamCity = team_city;
                                standingsService.Update(found_standing);
                            }
                        }
                        else if (process_edit_menu_index == 2)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.Write("Enter the new count of victories: ");
                            int victories = int.Parse(Console.ReadLine());

                            if (found_standing.VictoriesCount != victories)
                            {
                                found_standing.VictoriesCount = victories;
                                standingsService.Update(found_standing);
                            }
                        }
                        else if (process_edit_menu_index == 3)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.Write("Enter the new count of loses: ");
                            int loses = int.Parse(Console.ReadLine());

                            if (found_standing.LosesCount != loses)
                            {
                                found_standing.LosesCount = loses;
                                standingsService.Update(found_standing);
                            }
                        }
                        else if (process_edit_menu_index == 4)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.WriteLine("Enter the new count of draws: ");
                            int draws = int.Parse(Console.ReadLine());

                            if (found_standing.DrawGamesCount != draws)
                            {
                                found_standing.DrawGamesCount = draws;
                                standingsService.Update(found_standing);
                            }
                        }
                        else if (process_edit_menu_index == 5)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.Write("Enter the new count of goals: ");
                            int goals = int.Parse(Console.ReadLine());

                            if (found_standing.Goals != goals)
                            {
                                found_standing.Goals = goals;
                                standingsService.Update(found_standing);
                            }
                        }
                        else if (process_edit_menu_index == 6)
                        {
                            Console.SetCursorPosition(30, 7);
                            Console.Write("Enter the new count of goals missed: ");
                            int goals_missed = int.Parse(Console.ReadLine());

                            if (found_standing.GoalsMissed != goals_missed)
                            {
                                found_standing.GoalsMissed = goals_missed;
                                standingsService.Update(found_standing);
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("There are no teams with this name.");
                        Console.ReadKey();
                    }
                }
                else if (edit_menu_index == 2)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Enter the team's name: ");
                    string? team_name = Console.ReadLine();

                    Console.SetCursorPosition(30, 8);
                    Console.Write("Enter the team's city: ");
                    string? team_city = Console.ReadLine();

                    Standing? found_standing = standingsService.FindStanding(team_name, team_city);
                    if (found_standing != null)
                    {
                        Console.SetCursorPosition(15, 9);
                        Console.WriteLine($"Are you sure you want delete \"{found_standing.TeamName}\"?");
                        int delete_agreement_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Yes", "No");
                        if (delete_agreement_index == 0)
                        {
                            standingsService.Remove(found_standing);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("There are no teams with this name.");
                        Console.ReadKey();
                    }
                }
                else if (edit_menu_index == 3)
                {
                    return;
                }
            }
            else if (category_menu_index == 1)
            {
                int edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Add Match", "Delete Match", "Back");
                Console.Clear();
                if (edit_menu_index == 0)
                {
                    Console.Clear();

                    Console.SetCursorPosition(30, 7);
                    Console.Write("1st Team: ");
                    string? team1_name = Console.ReadLine();
                    Standing team1 = standingsService.FindStandingName(team1_name);
                    if(team1 == null)
                    {
                        Console.SetCursorPosition(30, 8);
                        Console.WriteLine("There are no teams with this name.");
                        Console.ReadKey();
                        return;
                    }

                    Console.SetCursorPosition(30, 8);
                    Console.Write("2nd Team: ");
                    string? team2_name = Console.ReadLine();
                    Standing team2 = standingsService.FindStandingName(team2_name);
                    if (team2 == null)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("There are no teams with this name.");
                        Console.ReadKey();
                        return;
                    }
                    if (team1 == team2)
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("The match can not have two same teams");
                        Console.ReadKey();
                        return;
                    }

                    Console.SetCursorPosition(30, 9);
                    Console.Write("1st Team Goals: ");
                    int team1_goals = int.Parse(Console.ReadLine());

                    Console.SetCursorPosition(30, 10);
                    Console.Write("2nd Team Goals: ");
                    int team2_goals = int.Parse(Console.ReadLine());

                    Console.SetCursorPosition(30, 11);
                    Console.Write("Date: ");
                    string line = Console.ReadLine();
                    DateTime dt;
                    while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine("Invalid date, please retry");
                        Console.ReadKey();
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine("                             ");
                        Console.SetCursorPosition(30, 11);
                        Console.Write("Date: ");
                        line = Console.ReadLine();
                    }

                    Match match = new Match() { Team1Id = team1.Id, Team1 = team1, Team2Id = team2.Id, Team2 = team2, Team1Goals = team1_goals, Team2Goals = team2_goals, Date = dt};
                    standingsService.AddMatch(match);

                }
                else if (edit_menu_index == 1)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Enter the 1st team's name: ");
                    string? team1_name = Console.ReadLine();

                    Console.SetCursorPosition(30, 8);
                    Console.Write("Enter the 2nd team's name: ");
                    string? team2_name = Console.ReadLine();

                    Console.SetCursorPosition(30, 9);
                    Console.Write("Date: ");
                    string line = Console.ReadLine();
                    DateTime dt;
                    while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("Invalid date, please retry");
                        Console.ReadKey();
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("                             ");
                        Console.SetCursorPosition(30, 9);
                        Console.Write("Date: ");
                        line = Console.ReadLine();
                    }

                    Standing? st1 = standingsService.FindStandingName(team1_name);
                    if(st1 == null)
                    {
                        return;
                    }
                    Standing? st2 = standingsService.FindStandingName(team2_name);
                    if (st2 == null)
                    {
                        return;
                    }

                    Match match = standingsService.GetMatchByTeamsAndDate(st1.Id, st2.Id, dt);
                    if (match != null)
                    {
                        Console.SetCursorPosition(15, 10);
                        Console.WriteLine($"Are you sure you want delete this match?");
                        int delete_agreement_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Yes", "No");
                        if (delete_agreement_index == 0)
                        {
                            standingsService.Remove(match);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("There are no matches like this.");
                        Console.ReadKey();
                    }
                }
                else if (edit_menu_index == 2)
                {
                    return;
                }
            }
            else if (category_menu_index == 2)
            {
                
            }
            else if (category_menu_index == 2)
            {
                return;
            }

        }

        public static void CustomSearch(StandingsService standingsService)
        {
            int category_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Teams", "Matches", "Back");
            Console.Clear();
            if(category_queries_index == 0)
            {
                int custom_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Search team by name", "Search team by city", "Search team by name and city", "Back");
                Console.Clear();
                if (custom_queries_index == 0)
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Enter the team's name: ");
                    string? team_name = Console.ReadLine();
                    Standing? standing = standingsService.FindStandingName(team_name);
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (custom_queries_index == 1)
                {
                    Console.SetCursorPosition(30, 8);
                    Console.Write("Enter the team's city: ");
                    string? team_city = Console.ReadLine();
                    Standing? standing = standingsService.FindStandingCity(team_city);
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (custom_queries_index == 2)
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
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (custom_queries_index == 3)
                {
                    return;
                }
            }
            else if (category_queries_index == 1)
            {
                int custom_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Search matches by team", "Search matches by date", "Back");
                Console.Clear();
                if (custom_queries_index == 0) 
                {
                    Console.SetCursorPosition(30, 7);
                    Console.Write("Enter the team's name: ");
                    string? team_name = Console.ReadLine();
                    Standing? standing = standingsService.FindStandingName(team_name);
                    if(standing != null)
                    {
                        List<Match>? matches = standingsService.GetMatchesByTeam(standing.Id);
                        if (matches != null)
                        {
                            foreach (var match in matches)
                            {
                                string Team1Name = new string(string.Empty);
                                string Team2Name = new string(string.Empty);
                                foreach (var team in standingsService.GetAllStandings())
                                {
                                    if (match.Team1Id == team.Id)
                                    {
                                        Team1Name = team.TeamName;
                                    }
                                    else if (match.Team2Id == team.Id)
                                    {
                                        Team2Name = team.TeamName;
                                    }
                                }
                                Console.WriteLine($"1st Team: {Team1Name}, 2nd Team: {Team2Name}, 1st Team Goals: {match.Team1Goals}, 2nd Team Goals: {match.Team2Goals}, Date: {match.Date}");
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                if (custom_queries_index == 1)
                {
                    Console.SetCursorPosition(30, 11);
                    Console.Write("Date: ");
                    string line = Console.ReadLine();
                    DateTime dt;
                    while (!DateTime.TryParseExact(line, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
                    {
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine("Invalid date, please retry");
                        Console.ReadKey();
                        Console.SetCursorPosition(30, 11);
                        Console.WriteLine("                             ");
                        Console.SetCursorPosition(30, 11);
                        Console.Write("Date: ");
                        line = Console.ReadLine();
                    }

                    List<Match>? matches = standingsService.GetMatchesByDate(dt);
                    if(matches != null)
                    {
                        foreach (var match in matches)
                        {
                            string Team1Name = new string(string.Empty);
                            string Team2Name = new string(string.Empty);
                            foreach (var team in standingsService.GetAllStandings())
                            {
                                if (match.Team1Id == team.Id)
                                {
                                    Team1Name = team.TeamName;
                                }
                                else if (match.Team2Id == team.Id)
                                {
                                    Team2Name = team.TeamName;
                                }
                            }
                            Console.WriteLine($"1st Team: {Team1Name}, 2nd Team: {Team2Name}, 1st Team Goals: {match.Team1Goals}, 2nd Team Goals: {match.Team2Goals}, Date: {match.Date}");
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }

                }
                if (custom_queries_index == 2)
                {
                    return;
                }
            }
            else if (category_queries_index == 2)
            {
                return;
            }
            

        }

        public static void DefaultSearch(StandingsService standingsService)
        {
            int category_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Standings", "Matches", "Back");
            Console.Clear();
            if (category_index == 0)
            {
                int default_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "All standings", "The most victories", "The most loses", "The most draws", "The most goals", "The most goals missed", "Goal Difference", "Top 3 most points", "Top 1 most points", "Top 3 least points", "Top 1 least points","Back");
                Console.Clear();
                if (default_queries_index == 0)
                {
                    foreach (var standing in standingsService.GetAllStandings())
                    {
                        standingsService.PrintStanding(standing);
                    }
                    Console.ReadKey();
                }
                else if (default_queries_index == 1)
                {
                    Standing? standing = standingsService.GetTeamMostVictories();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 2)
                {
                    Standing? standing = standingsService.GetTeamMostLoses();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 3)
                {
                    Standing? standing = standingsService.GetTeamMostDrawGames();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 4)
                {
                    Standing? standing = standingsService.GetTeamMostGoalsScored();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 5)
                {
                    Standing? standing = standingsService.GetTeamMostGoalsMissed();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 6)
                {
                    Dictionary<string, int> standings = standingsService.GetTeamGoalDifference();
                    foreach(var st in standings)
                    {
                        Console.WriteLine($"Team: {st.Key}, Goals Difference: {st.Value}");
                    }
                    Console.ReadKey();
                }
                else if (default_queries_index == 7)
                {
                    List<Standing>? standings = standingsService.GetStandingsTop3MostPoints();
                    foreach (var standing in standings)
                    {
                        standingsService.PrintStanding(standing);
                    }
                    Console.ReadKey();
                }
                else if (default_queries_index == 8)
                {
                    Standing? standing = standingsService.GetStandingMostPoints();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 9)
                {
                    List<Standing>? standings = standingsService.GetStandingsTop3LeastPoints();
                    foreach (var standing in standings)
                    {
                        standingsService.PrintStanding(standing);
                    }
                    Console.ReadKey();
                }
                else if (default_queries_index == 10)
                {
                    Standing? standing = standingsService.GetStandingLeastPoints();
                    if (standing != null)
                    {
                        standingsService.PrintStanding(standing);
                        Console.ReadKey();
                    }
                    else
                    {
                        return;
                    }
                }
                else if (default_queries_index == 11)
                {
                    return;
                }
            }
            else if(category_index == 1)
            {
                int default_queries_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "All matches", "Back");
                Console.Clear();
                if (default_queries_index == 0)
                {
                    foreach (var match in standingsService.GetAllMatches())
                    {
                        string Team1Name = new string(string.Empty);
                        string Team2Name = new string(string.Empty);
                        foreach (var team in standingsService.GetAllStandings())
                        {
                            if(match.Team1Id == team.Id)
                            {
                                Team1Name = team.TeamName;
                            }
                            else if (match.Team2Id == team.Id)
                            {
                                Team2Name = team.TeamName;
                            }
                        }
                        Console.WriteLine($"1st Team: {Team1Name}, 2nd Team: {Team2Name}, 1st Team Goals: {match.Team1Goals}, 2nd Team Goals: {match.Team2Goals}, Date: {match.Date}");
                    }
                    Console.ReadKey();
                }
                if (default_queries_index == 1)
                {
                    return;
                }

            }
            else if (category_index == 2)
            {
                return;
            }

        }
    }
}

