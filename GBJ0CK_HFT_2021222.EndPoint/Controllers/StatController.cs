using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GBJ0CK_HFT_2021222.EndPoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ILolPlayerLogic lolplayerlogic;
        ILolManagerLogic lolmanagerlogic;

        public StatController(ILolPlayerLogic lolplayerlogic, ILolManagerLogic lolmanagerlogic)
        {
            this.lolplayerlogic = lolplayerlogic;
            this.lolmanagerlogic = lolmanagerlogic;
        }

        [HttpGet]
        public IEnumerable<LolPlayer> GetLolplayersAtAgeFourty()
        {
            return lolplayerlogic.GetLolplayersAtAgeFourty();
        }
        [HttpGet]
        public IEnumerable<LolPlayer> GetLolPlayerWhereWinIsOverTen() 
        {
            return lolplayerlogic.GetLolPlayerWhereWinIsOverTen();
        }
        [HttpGet]
        public IEnumerable<LolPlayer> GetLolplayersWhereTeamNameIsRoll()
        {
            return lolplayerlogic.GetLolplayersWhereTeamNameIsRoll();
        }

        [HttpGet]
        public IEnumerable<LolManager> GetLolManagertName()
        {
            return lolmanagerlogic.GetLolManagertName();
        }
        [HttpGet]
        public IEnumerable<LolManager> GetLolManagertAtTwenty()
        {
            return lolmanagerlogic.GetLolManagertAtTwenty();
        }
    }
}
