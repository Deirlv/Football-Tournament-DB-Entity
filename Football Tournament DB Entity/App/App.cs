using DictionaryApp;
using FootBallTournament.DAL.Entities;
using FootBallTournament.DAL.Service;
using FootBallTournament.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_Tournament_DB_Entity.App
{
    public static class App
    {
        public static void Edit(StandingsService standingsService)
        {
            int edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Add Team", "Edit Team", "Delete Team", "Back");
            Console.Clear();
            if(edit_menu_index == 0 ) 
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
                    }
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

                using (var context = new FootBallTournamentContext())
                {
                    Standing? found_standing = standingsService.FindStanding(team_name, team_city);
                    if (found_standing != null)
                    {
                        Console.Clear();

                        Console.SetCursorPosition(30, 7);
                        Console.WriteLine("Enter what do you want to edit: ");
                        int process_edit_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center,
                            "Team's name", "Team's city", "Count of victories", "Count of loses", "Count of draws", "Count of goals", "Count of goals missed");
                        if(process_edit_menu_index == 0)
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
                                    standingsService.UpdateStanding(found_standing);
                                    context.SaveChanges();
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
                                standingsService.UpdateStanding(found_standing);
                                context.SaveChanges();
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
                                standingsService.UpdateStanding(found_standing);
                                context.SaveChanges();
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
                                standingsService.UpdateStanding(found_standing);
                                context.SaveChanges();
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
                                standingsService.UpdateStanding(found_standing);
                                context.SaveChanges();
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
                                standingsService.UpdateStanding(found_standing);
                                context.SaveChanges();
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
                                standingsService.UpdateStanding(found_standing);
                                context.SaveChanges();
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
            }
            else if (edit_menu_index == 2)
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
                        if(delete_agreement_index == 0)
                        {
                            standingsService.RemoveStanding(found_standing);
                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("There are no teams with this name.");
                        Console.ReadKey();
                    }
                }
            }
            else if (edit_menu_index == 3)
            {
                return;
            }
        }

        public static void CustomSearch()
        {

        }

        public static void DefaultSearch()
        {

        }
    }
}

