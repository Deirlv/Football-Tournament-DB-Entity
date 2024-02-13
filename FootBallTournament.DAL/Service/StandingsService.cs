using FootBallTournament.DAL.Entities;
using FootBallTournament.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallTournament.DAL.Service
{
    public class StandingsService
    {
        private readonly StandingsRepository _standingsRepository;

        public StandingsService(FootBallTournamentContext context)
        {
            _standingsRepository = new StandingsRepository(context);
        }

        public bool AddStanding(Standing standing)
        {
            bool is_unique = IsUnique(standing);

            if (is_unique)
            {
                _standingsRepository.Add(standing);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveStanding(Standing standing)
        {
            _standingsRepository.Delete(standing);
        }

        public void UpdateStanding(Standing standing)
        {
            _standingsRepository.Update(standing);
        }

        public List<Standing> GetAllStandings()
        {
            return _standingsRepository.GetAll();
        }

        public bool IsUnique(Standing standing)
        {
            var standings = _standingsRepository.GetAll();
            var exist_standing = standings.FirstOrDefault(s => s.TeamName == standing.TeamName);

            if (exist_standing == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Standing? UniqueFill(string teamName, string teamCity, int victoriesCount, int losesCount, int drawGamesCount, int goals, int goalsMissed)
        {
            var standing = new Standing
            {
                TeamName = teamName,
                TeamCity = teamCity,
                VictoriesCount = victoriesCount,
                LosesCount = losesCount,
                DrawGamesCount = drawGamesCount,
                Goals = goals,
                GoalsMissed = goalsMissed
            };

            bool is_unique = IsUnique(standing);

            if (is_unique)
            {
                return standing;
            }
            else
            {
                return null;
            }
        }

        public Standing? FindStanding(string teamName, string teamCity)
        {
            return _standingsRepository.GetAll().FirstOrDefault(s => s.TeamName == teamName && s.TeamCity == teamCity);
        }

        public Standing? FindStandingName(string teamName)
        {
            return _standingsRepository.GetAll().FirstOrDefault(s => s.TeamName == teamName);
        }

        public Standing? FindStandingCity(string teamCity)
        {
            return _standingsRepository.GetAll().FirstOrDefault(s => s.TeamCity == teamCity);
        }

        public Standing? GetTeamMostVictories()
        {
            return _standingsRepository.GetAll().OrderByDescending(s => s.VictoriesCount).FirstOrDefault();
        }

        public Standing? GetTeamMostLoses()
        {
            return _standingsRepository.GetAll().OrderByDescending(s => s.LosesCount).FirstOrDefault();
        }

        public Standing? GetTeamMostDrawGames()
        {
            return _standingsRepository.GetAll().OrderByDescending(s => s.DrawGamesCount).FirstOrDefault();
        }

        public Standing? GetTeamMostGoalsScored()
        {
            return _standingsRepository.GetAll().OrderByDescending(s => s.Goals).FirstOrDefault();
        }

        public Standing? GetTeamMostGoalsMissed()
        {
            return _standingsRepository.GetAll().OrderByDescending(s => s.GoalsMissed).FirstOrDefault();
        }

    }
}
