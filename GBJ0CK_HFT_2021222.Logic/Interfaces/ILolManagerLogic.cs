using GBJ0CK_HFT_2021222.Models;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Logic
{
    public interface ILolManagerLogic
    {
        void Create(LolManager item);
        void Delete(int id);
        LolManager Read(int id);
        IQueryable<LolManager> ReadAll();
        void Update(LolManager item);
    }
}