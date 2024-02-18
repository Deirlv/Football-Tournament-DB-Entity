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
using Newtonsoft.Json;

namespace Football_Tournament_DB_Entity
{
    internal class Program
    {

        public class Data
        {
            public List<Standing> Standing { get; set; }
            public List<Player> Player { get; set; }
            public List<Match> Match { get; set; }
        }

        static public void TestFill(StandingsService standingsService, string json_file)
        {
            string json = File.ReadAllText(json_file);
            var data = JsonConvert.DeserializeObject<Data>(json);

            foreach (var standing in data.Standing)
            {
                standingsService.AddStanding(standing);
            }

            foreach (var player in data.Player)
            {
                standingsService.AddPlayer(player);
            }

            foreach (var match in data.Match)
            {
                standingsService.AddMatch(match);
            }
        }

        static void Main(string[] args)
        {
            var standingsService = new StandingsService();
            //TestFill(standingsService, "testfill.json"); Я спробував їх заповнювати, але виникає помилка у SaveChanges через зовнішні ключі

            while (true)
            {
                Console.Clear();
                int start_menu_index = ConsoleMenu.SelectVertical(HPosition.Center, VPosition.Center, HorizontalAlignment.Center, "Edit", "Custom Search", "Default Search");
                Console.Clear();
                switch (start_menu_index)
                {
                    case 0: App.App.Edit(standingsService); break; 

                    case 1: App.App.CustomSearch(standingsService); break;

                    case 2: App.App.DefaultSearch(standingsService); break;
                        
                }
            }
        }
    }
}
