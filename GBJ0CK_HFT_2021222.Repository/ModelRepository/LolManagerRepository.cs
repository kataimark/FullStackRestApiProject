using GBJ0CK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Repository
{
    public class LolManagerRepository : Repository<LolManager>, IRepository<LolManager>
    {
        public LolManagerRepository(LolDbContext ctx) : base(ctx)
        {

        }

        public override LolManager Read(int id)
        {
            return ctx.LolManagers.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(LolManager item)
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
