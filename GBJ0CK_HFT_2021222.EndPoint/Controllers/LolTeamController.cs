using GBJ0CK_HFT_2021222.EndPoint.Services;
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
        IHubContext<SignalRHub> hub;

        public LolTeamController(ILolTeamLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("LolTeamCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] LolTeam value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("LolTeamUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var LolTeamToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("LolTeamDeleted", LolTeamToDelete);
            this.hub.Clients.All.SendAsync("LolPlayerDeleted", null);

        }

    }
}
