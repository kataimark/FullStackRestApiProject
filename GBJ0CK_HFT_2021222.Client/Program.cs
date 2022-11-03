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


        }
    }
}
