

namespace FootBallTournament.DAL.Entities
{
    public class Match
    {
        public int Id { get; set; }

        public Standing Team1 { get; set; }

        public Standing Team2 { get; set; }

        public int Team1Goals { get; set; }

        public int Team2Goals { get; set; }

        public DateTime Date { get; set; }

    }
}
