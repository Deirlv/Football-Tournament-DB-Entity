using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootBallTournament.DAL.Entities;

namespace FootBallTournament.DAL.Repository
{
    public interface IStandingsRepository
    {
        Standing GetById(int id);
        void Add(Standing standings);
        void Update(Standing standings);
        void Delete(Standing standings);
        List<Standing> GetAll();
    }
}
