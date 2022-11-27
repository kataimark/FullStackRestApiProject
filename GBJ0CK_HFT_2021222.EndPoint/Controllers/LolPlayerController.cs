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
    public class LolPlayerController : ControllerBase
    {
        ILolPlayerLogic logic;
        IHubContext<SignalRHub> hub;

        public LolPlayerController(ILolPlayerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        // GET: LolPlayer
        [HttpGet]
        public IEnumerable<LolPlayer> Get()
        {
            return logic.ReadAll();
        }

        // GET LolPlayer/5
        [HttpGet("{id}")]
        public LolPlayer Get(int id)
        {
            return logic.Read(id);
        }

        // POST LolPlayer
        [HttpPost]
        public void Post([FromBody] LolPlayer value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("LolPlayerCreated", value);
        }

        // PUT LolPlayer/5
        [HttpPut]
        public void Put([FromBody] LolPlayer value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("LolPlayerUpdated", value);
        }

        // DELETE LolPlayer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var LolPlayerToDelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("LolPlayerDeleted", LolPlayerToDelete);
        }

    }
}
