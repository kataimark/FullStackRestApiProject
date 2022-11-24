using System;
using System.Collections.Generic;
using System.Linq;
using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;

namespace GBJ0CK_HFT_2021222.Logic
{
    public class LolPlayerLogic : ILolPlayerLogic
    {
        IRepository<LolPlayer> repo;

        public LolPlayerLogic(IRepository<LolPlayer> repo)
        {
            this.repo = repo;
        }

        public void Create(LolPlayer item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("PlayerName too short...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public LolPlayer Read(int id)
        {
            var player = this.repo.Read(id);
            if (player == null)
            {

                throw new ArgumentException("Player not exists.");

            }
            return player;
        }

        public IQueryable<LolPlayer> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(LolPlayer item)
        {
            this.repo.Update(item);
        }

        public double? GetAverageAge(string role)
        {
            return this.repo
            .ReadAll()
            .Where(t => t.Role == role)
            .Average(t => t.Age);
        }

        public double? GetWinsByChampion(string role)
        {
            return this.repo
            .ReadAll()
            .Where(t => t.Role == role)
            .Average(t => t.Name.Length);
        }

    }
}
