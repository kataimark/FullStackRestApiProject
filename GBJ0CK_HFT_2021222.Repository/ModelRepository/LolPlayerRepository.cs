using GBJ0CK_HFT_2021222.Models;
using System;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Repository
{
    public class LolPlayerRepository : Repository<LolPlayer>
    {
        public LolPlayerRepository(LolDbContext ctx) : base(ctx)
        {

        }

        public override LolPlayer Read(int id)
        {
            return ctx.LolPlayers.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(LolPlayer obj)
        {
            var oldLolPlayer = Read(obj.Id);
            oldLolPlayer.Id = obj.Id;
            oldLolPlayer.Name = obj.Name;
            oldLolPlayer.Age = obj.Age;
            oldLolPlayer.Role = obj.Role;
            oldLolPlayer.LolTeam_id = obj.LolTeam_id;
            ctx.SaveChanges();
        }
        public override void Delete(int id)
        {
            ctx.Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
