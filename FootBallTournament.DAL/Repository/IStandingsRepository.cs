using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FootBallTournament.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootBallTournament.DAL.Repository
{
    public interface IStandingsRepository
    {
        TEntity? GetById<TEntity>(int id) where TEntity : class;
        
        void Add(object standings);
        void Update(object standings);
        void Delete(object standings);
        public List<TEntity> GetAll<TEntity>() where TEntity : class;
    }
}
