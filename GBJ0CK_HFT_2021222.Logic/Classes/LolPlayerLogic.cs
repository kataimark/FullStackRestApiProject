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

        public void Create(LolPlayer item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("PlayerName too short...");
            }
            this.playerRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.playerRepo.Delete(id);
        }

        public LolPlayer Read(int id)
        {
            var player = this.playerRepo.Read(id);
            if (player == null)
            {

                throw new ArgumentException("Player not exists.");

            }
            return player;
        }

        public IQueryable<LolPlayer> ReadAll()
        {
            return this.playerRepo.ReadAll();
        }

        public void Update(LolPlayer item)
        {
            this.playerRepo.Update(item);
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
