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

        public void Create(LolManager obj)
        {
            if (obj.ManagerName.Any(c => char.IsDigit(c)) || obj.Age<0)
            {
                throw new ArgumentException("ManagerName can't contain numbers, Age cant contain letters");
            }
            if (obj.ManagerName == "" || obj.Age == 0)
            {
                throw new ArgumentNullException("Can't be null");
            }
            managerRepo.Create(obj);
        }

        public void Delete(int id)
        {
            managerRepo.Delete(id);
        }

        public LolManager Read(int id)
        {
            if (id < managerRepo.ReadAll().Count() + 1)
                return managerRepo.Read(id);
            else
                throw new IndexOutOfRangeException("Id is to big!");
        }

        public IQueryable<LolManager> ReadAll()
        {
            return managerRepo.ReadAll();
        }

        public void Update(LolManager obj)
        {
            managerRepo.Update(obj);
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
