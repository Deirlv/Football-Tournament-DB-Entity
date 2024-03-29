﻿using FootBallTournament.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public TEntity? GetById<TEntity>(int id) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Find(id);
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

        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public List<Match> GetAllMatches()
        {
            return _dbContext.Set<Match>().Include(m => m.Team1).Include(m => m.Team2).ToList();
        }
    }
}
