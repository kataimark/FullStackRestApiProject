using GBJ0CK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Repository
{
    public class LolTeamRepository : Repository<LolTeam>
    {
        public LolTeamRepository(LolDbContext ctx) : base(ctx)
        {

        }

        public override LolTeam Read(int id)
        {
            return ctx.LolTeams.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(LolTeam obj)
        {
            var oldLolTeam = Read(obj.Id);
            oldLolTeam.Id = obj.Id;
            oldLolTeam.TeamName = obj.TeamName;
            oldLolTeam.Wins = obj.Wins;
            oldLolTeam.WasChampion = obj.WasChampion;
            oldLolTeam.LolManager_id = obj.LolManager_id;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
