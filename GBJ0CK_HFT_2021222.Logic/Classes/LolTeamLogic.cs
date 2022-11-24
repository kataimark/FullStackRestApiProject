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
        IRepository<LolTeam> repo;

        public LolTeamLogic(IRepository<LolTeam> repo)
        {
            this.repo = repo;
        }

        public void Create(LolTeam item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public LolTeam Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<LolTeam> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(LolTeam item)
        {
            this.repo.Update(item);
        }
    }
}
