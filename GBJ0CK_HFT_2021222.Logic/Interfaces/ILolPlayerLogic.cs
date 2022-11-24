using GBJ0CK_HFT_2021222.Models;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Logic
{
    public interface ILolPlayerLogic
    {
        void Create(LolPlayer item);
        void Delete(int id);
        double? GetAverageAge(string role);
        double? GetWinsByChampion(string role);
        LolPlayer Read(int id);
        IQueryable<LolPlayer> ReadAll();
        void Update(LolPlayer item);
    }
}