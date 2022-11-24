using GBJ0CK_HFT_2021222.Models;
using GBJ0CK_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBJ0CK_HFT_2021222.Logic
{
    public class LolManagerLogic : ILolManagerLogic
    {
        IRepository<LolManager> repo;

        public LolManagerLogic(IRepository<LolManager> repo)
        {
            this.repo = repo;
        }

        public void Create(LolManager item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public LolManager Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<LolManager> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(LolManager item)
        {
            this.repo.Update(item);
        }
    }
}
