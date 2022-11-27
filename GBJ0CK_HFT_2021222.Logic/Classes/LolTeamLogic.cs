using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Logic
{
    public class LolTeamLogic : ILolTeamLogic
    {
        IRepository<LolTeam> Teamrepo;

        public LolTeamLogic(IRepository<LolTeam> repo)
        {
            this.Teamrepo = repo;
        }

        public void Create(LolTeam obj)
        {
            if (obj.TeamName == "")
            {
                throw new ArgumentNullException("Can't be null");
            }
            if (obj.Wins < 0)
            {
                throw new ArgumentException("Negative win is not allowed");
            }
            Teamrepo.Create(obj);
        }

        public void Delete(int id)
        {
            Teamrepo.Delete(id);
        }

        public LolTeam Read(int id)
        {
            if (id < Teamrepo.ReadAll().Count() + 1)
                return Teamrepo.Read(id);
            else
                throw new IndexOutOfRangeException("Id is to big!");
        }

        public IQueryable<LolTeam> ReadAll()
        {
            return Teamrepo.ReadAll();
        }

        public void Update(LolTeam obj)
        {
            Teamrepo.Update(obj);
        }
    }
}
