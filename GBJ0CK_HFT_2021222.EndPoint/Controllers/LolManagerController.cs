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
    public class LolManagerController : ControllerBase
    {
        ILolManagerLogic logic;
        IHubContext<SignalRHub> hub;

        public LolManagerController(ILolManagerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        [HttpGet]
        public IEnumerable<LolManager> Get()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public LolManager Get(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] LolManager value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("LolManagerCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] LolManager value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("LolManagerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var LolManagerToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("LolManagerDeleted", LolManagerToDelete);
            this.hub.Clients.All.SendAsync("LolTeamDeleted", null);
            this.hub.Clients.All.SendAsync("LolPlayerrDeleted", null);
        }
    }
}
