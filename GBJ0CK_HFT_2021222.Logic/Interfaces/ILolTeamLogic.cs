using GBJ0CK_HFT_2021222.Models;
using System.Linq;

namespace GBJ0CK_HFT_2021222.Logic
{
    public interface ILolTeamLogic
    {
        void Create(LolTeam item);
        void Delete(int id);
        LolTeam Read(int id);
        IQueryable<LolTeam> ReadAll();
        void Update(LolTeam item);
    }
}