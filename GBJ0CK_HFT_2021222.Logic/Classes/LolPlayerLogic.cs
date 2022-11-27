using System;
using System.Collections.Generic;
using System.Linq;
using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;

namespace GBJ0CK_HFT_2021222.Logic
{
    public class LolPlayerLogic : ILolPlayerLogic
    {
        IRepository<LolPlayer> playerRepo;
        IRepository<LolTeam> teamRepo;
        IRepository<LolManager> managerRepo;

        public LolPlayerLogic(IRepository<LolPlayer> playerRepo, IRepository<LolTeam> teamRepo, IRepository<LolManager> managerRepo)
        {
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.managerRepo = managerRepo;
        }
        public void Create(LolPlayer obj)
        {
            if (obj.Name == "" || obj.Role == "")
            {
                throw new ArgumentNullException("Can't be null");
            }
            if (obj.Name.Any(c => char.IsDigit(c)) || obj.Role.Any(c => char.IsDigit(c)))
            {
                throw new ArgumentException("Name and Role can't contain numbers because they are text");
            }
            playerRepo.Create(obj);
        }

        public void Delete(int id)
        {
            playerRepo.Delete(id);
        }

        public LolPlayer Read(int id)
        {
            if (id < playerRepo.ReadAll().Count() + 1)
                return playerRepo.Read(id);
            else
                throw new IndexOutOfRangeException("Id is to big!");

        }

        public IQueryable<LolPlayer> ReadAll()
        {
            return playerRepo.ReadAll();
        }

        public void Update(LolPlayer obj)
        {
            playerRepo.Update(obj);
        }

        public IEnumerable<LolPlayer> GetLolplayersAtAgeFourty()
        {
            var q = from lolplayers in playerRepo.ReadAll()
                    join lolteams in teamRepo.ReadAll()
                    on lolplayers.LolTeam_id equals lolteams.Id
                    join lolmanagers in managerRepo.ReadAll()
                    on lolteams.LolManager_id equals lolmanagers.Id
                    where lolmanagers.Age == 40
                    select lolplayers;

            return q;
        }
        public IEnumerable<LolPlayer> GetLolPlayerWhereWinIsOverTen()
        {
            var q = from lolplayers in playerRepo.ReadAll()
                    join lolteams in teamRepo.ReadAll()
                    on lolplayers.LolTeam_id equals lolteams.Id
                    where lolteams.Wins > 10
                    select lolplayers;
            return q;
        }

        public IEnumerable<LolPlayer> GetLolplayersWhereTeamNameIsRoll()
        {
            var q = from lolplayers in playerRepo.ReadAll()
                    join lolteams in teamRepo.ReadAll()
                    on lolplayers.LolTeam_id equals lolteams.Id
                    where lolteams.TeamName == "ROLL"
                    select lolplayers;
            return q;
        }

    }
}
