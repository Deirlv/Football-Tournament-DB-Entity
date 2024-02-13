
namespace FootBallTournament.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Country { get; set; }

        public int JerseyNumber { get; set; }

        public string Position { get; set; }

        public Standing? Team { get; set; }
    }
}
