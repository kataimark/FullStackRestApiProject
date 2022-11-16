using GBJ0CK_HFT_2021222.Models;
using System;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Repository
{
    public class LolPlayerRepository : Repository<LolPlayer>, IRepository<LolPlayer>
    {
        public LolPlayerRepository(LolDbContext ctx) : base(ctx)
        {

        }

        public override LolPlayer Read(int id)
        {
            return ctx.LolPlayers.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(LolPlayer item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));

            }
            ctx.SaveChanges();
        }
    }
}
