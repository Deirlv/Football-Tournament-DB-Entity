namespace FootBallTournament.DAL.Entities
{
    public class Standing
    {
        public int Id { get; set; }

        public string TeamName { get; set; }

        public string TeamCity { get; set; }

        public int VictoriesCount { get; set; }

        public int LosesCount { get; set; }

        public int DrawGamesCount { get; set; }

        public int Goals { get; set; }

        public int GoalsMissed { get; set; }

        public List<Player>? players { get; set; }

    }
}
