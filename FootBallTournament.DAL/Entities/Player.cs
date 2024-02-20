
using System.ComponentModel.DataAnnotations;

namespace FootBallTournament.DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Country { get; set; }

        public int JerseyNumber { get; set; }

        [MaxLength(20)]
        public string Position { get; set; }

        public virtual Standing? Team { get; set; }
    }
}
