using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using System;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            LolDbContext ctx = new LolDbContext();

            ctx.LolTeams.ToList()
                .ForEach(t => Console.WriteLine(t.TeamName));
            ctx.LolManagers.ToList()
                .ForEach(t => Console.WriteLine(t.Id +" " + t.ManagerName ));
            ctx.LolPlayers.ToList()
                .ForEach(t => Console.WriteLine(t.Name + " " + t.Role));

            var lolplayerrepo = new LolPlayerRepository(ctx);
            var lolteamrepo = new LolTeamRepository(ctx);
            var lolmanagerrepo = new LolManagerRepository(ctx);


            var lolplayerlogic = new LolPlayerLogic(lolplayerrepo);
            var lolteamlogic = new LolTeamLogic(lolteamrepo);
            var lolmanagerlogic = new LolManagerLogic(lolmanagerrepo);

        }
    }
}
