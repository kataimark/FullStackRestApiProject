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

        public void Create(LolTeam item)
        {
            this.Teamrepo.Create(item);
        }

        public void Delete(int id)
        {
            this.Teamrepo.Delete(id);
        }

        public LolTeam Read(int id)
        {
            return this.Teamrepo.Read(id);
        }

        public IQueryable<LolTeam> ReadAll()
        {
            return this.Teamrepo.ReadAll();
        }

        public void Update(LolTeam item)
        {
            this.Teamrepo.Update(item);
        }
    }
}
