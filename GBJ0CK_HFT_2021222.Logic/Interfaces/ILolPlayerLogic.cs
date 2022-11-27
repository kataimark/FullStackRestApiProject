using GBJ0CK_HFT_2021222.Models;
using System.Collections.Generic;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Logic
{
    public interface ILolPlayerLogic
    {
        void Create(LolPlayer item);
        void Delete(int id);
        LolPlayer Read(int id);
        IQueryable<LolPlayer> ReadAll();
        void Update(LolPlayer item);

        IEnumerable<LolPlayer> GetLolplayersAtAgeFourty();
        IEnumerable<LolPlayer> GetLolplayersAtAgeTwenty();
        IEnumerable<LolPlayer> GetLolPlayerWhereWinIsOverTen();
        IEnumerable<LolPlayer> GetLolplayersWhereTeamNameIsRoll();
    }
}