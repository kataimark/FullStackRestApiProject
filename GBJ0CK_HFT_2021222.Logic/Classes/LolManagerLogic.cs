using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Logic
{
    public class LolManagerLogic : ILolManagerLogic
    {
        IRepository<LolPlayer> playerRepo;
        IRepository<LolTeam> teamRepo;
        IRepository<LolManager> managerRepo;

        public LolManagerLogic(IRepository<LolPlayer> playerRepo, IRepository<LolTeam> teamRepo, IRepository<LolManager> managerRepo)
        {
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.managerRepo = managerRepo;
        }

        public void Create(LolManager item)
        {
            this.managerRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.managerRepo.Delete(id);
        }

        public LolManager Read(int id)
        {
            return this.managerRepo.Read(id);
        }

        public IQueryable<LolManager> ReadAll()
        {
            return this.managerRepo.ReadAll();
        }

        public void Update(LolManager item)
        {
            this.managerRepo.Update(item);
        }

        public IEnumerable<LolManager> GetLolManagertName()
        {
            var q = from lolplayers in playerRepo.ReadAll()
                    join lolteams in teamRepo.ReadAll()
                    on lolplayers.LolTeam_id equals lolteams.Id
                    join lolmanagers in managerRepo.ReadAll()
                    on lolteams.LolManager_id equals lolmanagers.Id
                    where lolplayers.Name == "Freid"
                    select lolmanagers;
            return q;
        }

        public IEnumerable<LolManager> GetLolManagertAtTwenty()
        {
            var q = from lolplayers in playerRepo.ReadAll()
                    join lolteams in teamRepo.ReadAll()
                    on lolplayers.LolTeam_id equals lolteams.Id
                    join lolmanagers in managerRepo.ReadAll()
                    on lolteams.LolManager_id equals lolmanagers.Id
                    where lolplayers.Age == 20
                    select lolmanagers;
            return q;
        }
    }
}
