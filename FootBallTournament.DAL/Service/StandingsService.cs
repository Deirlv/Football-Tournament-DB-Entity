using FootBallTournament.DAL.Entities;
using FootBallTournament.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FootBallTournament.DAL.Service
{
    public class StandingsService
    {
        private readonly StandingsRepository _standingsRepository;

        public StandingsService()
        {
            _standingsRepository = new StandingsRepository(new FootBallTournamentContext());
        }

        public bool AddStanding(Standing standing)
        {
            if (IsUnique(standing))
            {
                _standingsRepository.Add(standing);
                return true;
            }
            return false;
        }
        public void AddMatch(Match standing)
        {
            _standingsRepository.Add(standing);
        }
        public void AddPlayer(Player standing)
        {
            _standingsRepository.Add(standing);
        }
        public void Remove(object standing)
        {
            _standingsRepository.Delete(standing);
        }

        public void Update(object standing)
        {
            _standingsRepository.Update(standing);
        }

        public List<Standing> GetAllStandings()
        {
            return _standingsRepository.GetAll<Standing>();
        }

        public List<Match> GetAllMatches()
        {
            return _standingsRepository.GetAll<Match>();
        }

        public List<Player> GetAllPlayers()
        {
            return _standingsRepository.GetAll<Player>();
        }

        public void PrintStanding(Standing standing)
        {
            Console.WriteLine($"Team: {standing.TeamName}, City: {standing.TeamCity}, Wins: {standing.VictoriesCount}, Loses: {standing.LosesCount}, Draws: {standing.DrawGamesCount}, Goals: {standing.Goals}, Goals Missed: {standing.GoalsMissed}");
        }

        public bool IsUnique(Standing standing)
        {
            var standings = _standingsRepository.GetAll<Standing>();
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
            return _standingsRepository.GetAll<Standing>().FirstOrDefault(s => s.TeamName == teamName && s.TeamCity == teamCity);
        }

        public Standing? FindStandingName(string teamName)
        {
            return _standingsRepository.GetAll<Standing>().FirstOrDefault(s => s.TeamName == teamName);
        }

        public Standing? FindStandingCity(string teamCity)
        {
            return _standingsRepository.GetAll<Standing>().FirstOrDefault(s => s.TeamCity == teamCity);
        }

        public Standing? GetTeamMostVictories()
        {
            return _standingsRepository.GetAll<Standing>().OrderByDescending(s => s.VictoriesCount).FirstOrDefault();
        }

        public Standing? GetTeamMostLoses()
        {
            return _standingsRepository.GetAll<Standing>().OrderByDescending(s => s.LosesCount).FirstOrDefault();
        }

        public Standing? GetTeamMostDrawGames()
        {
            return _standingsRepository.GetAll<Standing>().OrderByDescending(s => s.DrawGamesCount).FirstOrDefault();
        }

        public Standing? GetTeamMostGoalsScored()
        {
            return _standingsRepository.GetAll<Standing>().OrderByDescending(s => s.Goals).FirstOrDefault();
        }

        public Standing? GetTeamMostGoalsMissed()
        {
            return _standingsRepository.GetAll<Standing>().OrderByDescending(s => s.GoalsMissed).FirstOrDefault();
        }

        public Dictionary<string, int> GetTeamGoalDifference()
        {
            var goal_difference = new Dictionary<string,int>();

            var teams = _standingsRepository.GetAll<Standing>();

            foreach (var team in teams)
            {
                goal_difference.Add(team.TeamName, team.Goals - team.GoalsMissed);
            }

            return goal_difference;
        }
        public Standing? GetStandingById(int standingId)
        {
            return _standingsRepository.GetById<Standing>(standingId);
        }

        public Match? GetMatchById(int matchId)
        {
            return _standingsRepository.GetById<Match>(matchId);

        }

        public Match? GetMatchByTeamsAndDate(int team1id, int team2id, DateTime date)
        {
            Match? found_match = null;
            foreach (var match in _standingsRepository.GetAll<Match>())
            {
                if (match.Team1Id == team1id && match.Team2Id == team2id && match.Date == date)
                {
                    found_match = match;
                }
            }
            return found_match;
        }

        public List<Match>? GetMatchesByDate(DateTime date)
        {
            List<Match> matches = new List<Match>();
            foreach (var match in _standingsRepository.GetAll<Match>())
            {
                if(match.Date == date)
                {
                    matches.Add(match);
                }
            }
            return matches.Count != 0 ? matches : null;
        }

        public List<Match>? GetMatchesByTeam(int teamId)
        {
            List<Match> matches = new List<Match>();
            foreach (var match in _standingsRepository.GetAll<Match>())
            {
                if (match.Team1Id == teamId || match.Team2Id == teamId)
                {
                    matches.Add(match);
                }
            }
            return matches.Count != 0 ? matches : null;
        }

        public List<Standing>? GetStandingsTop3MostPoints()
        {
            var top3TeamsByPoints = _standingsRepository.GetAll<Standing>()
                .OrderByDescending(s => s.VictoriesCount * 3 + s.DrawGamesCount)
                .Take(3)
                .ToList();
            if(top3TeamsByPoints.Count == 0) 
            {
                return null;
            }
            return top3TeamsByPoints;
        }

        public Standing? GetStandingMostPoints()
        {
            var topTeamByPoints = _standingsRepository.GetAll<Standing>()
                .OrderByDescending(s => s.VictoriesCount * 3 + s.DrawGamesCount)
                .FirstOrDefault();
            return topTeamByPoints;
        }

        public List<Standing>? GetStandingsTop3LeastPoints()
        {
            var top3TeamsByPoints = _standingsRepository.GetAll<Standing>()
                .OrderBy(s => s.VictoriesCount * 3 + s.DrawGamesCount)
                .Take(3)
                .ToList();
            if (top3TeamsByPoints.Count == 0)
            {
                return null;
            }
            return top3TeamsByPoints;
        }

        public Standing? GetStandingLeastPoints()
        {
            var topTeamByPoints = _standingsRepository.GetAll<Standing>()
                .OrderBy(s => s.VictoriesCount * 3 + s.DrawGamesCount)
                .FirstOrDefault();
            return topTeamByPoints;
        }

    }
}
