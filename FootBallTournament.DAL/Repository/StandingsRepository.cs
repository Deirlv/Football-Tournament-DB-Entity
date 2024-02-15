using FootBallTournament.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBallTournament.DAL.Repository
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

        public void Add(object standing)
        {
            _dbContext.Add(standing);
            _dbContext.SaveChanges();
        }

        public void Update(object standing)
        {
            _dbContext.Entry(standing).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(object standing)
        {
            _dbContext.Remove(standing);
            _dbContext.SaveChanges();
        }

        public List<object> GetAll()
        {
            return new List<object>(); // це просто щоб помилки не було

            //ось тут як? Set<object> не дає написати. він чекає TEntity
            //return _dbContext.Set<object>.ToList();
        }
    }
}
