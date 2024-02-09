using FootBallTournament.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallTournament.DAL.StandingsRepository
{
    public class StandingsRepository : IStandingsRepository
    {
        private readonly DbContext _dbContext;

        public StandingsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Standing? GetById(int id)
        {
            return _dbContext.Set<Standing>().Find(id);
        }

        public void Add(Standing standing)
        {
            _dbContext.Set<Standing>().Add(standing);
            _dbContext.SaveChanges();
        }

        public void Update(Standing standing)
        {
            _dbContext.Entry(standing).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(Standing standing)
        {
            _dbContext.Set<Standing>().Remove(standing);
            _dbContext.SaveChanges();
        }

        public List<Standing> GetAll()
        {
            return _dbContext.Set<Standing>().ToList();
        }
    }
}
