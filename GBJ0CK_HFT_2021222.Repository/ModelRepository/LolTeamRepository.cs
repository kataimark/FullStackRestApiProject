﻿using GBJ0CK_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Repository
{
    public class LolTeamRepository : Repository<LolTeam>, IRepository<LolTeam>
    {
        public LolTeamRepository(LolDbContext ctx) : base(ctx)
        {

        }

        public override LolTeam Read(int id)
        {
            return ctx.LolTeams.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(LolTeam item)
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
