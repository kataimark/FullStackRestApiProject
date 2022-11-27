using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
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

        public LolPlayerController(ILolPlayerLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT LolPlayer/5
        [HttpPut]
        public void Put([FromBody] LolPlayer value)
        {
            logic.Update(value);
        }

        // DELETE LolPlayer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }

    }
}
