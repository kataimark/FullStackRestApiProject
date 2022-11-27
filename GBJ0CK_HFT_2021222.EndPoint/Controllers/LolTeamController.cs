using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GBJ0CK_HFT_2021222.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LolTeamController : ControllerBase
    {
        ILolTeamLogic logic;

        public LolTeamController(ILolTeamLogic logic)
        {
            this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<LolTeam> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public LolTeam Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] LolTeam value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] LolTeam value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }

    }
}
