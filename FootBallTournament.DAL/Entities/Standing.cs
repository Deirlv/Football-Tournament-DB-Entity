﻿using System.ComponentModel.DataAnnotations;

namespace FootBallTournament.DAL.Entities
{
    public class Standing
    {
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        public string TeamCity { get; set; }

        public int VictoriesCount { get; set; }

        public int LosesCount { get; set; }

        public int DrawGamesCount { get; set; }

        public int Goals { get; set; }

        public int GoalsMissed { get; set; }

        public virtual List<Player>? Players { get; set; }

        public virtual List<Match>? Matches { get; set; }

    }
}
