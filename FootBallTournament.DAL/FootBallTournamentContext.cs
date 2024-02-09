using FootBallTournament.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBallTournament.DAL
{
    public class FootBallTournamentContext : DbContext
    {
        public DbSet<Standing> Standings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-7P700PI\SQLEXPRESS;Initial Catalog=FootBallTournament;Integrated Security=True;Connect Timeout=30;");
        }
    }
}
