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
    [Route("[controller]")]
    [ApiController]
    public class LolTeamController : ControllerBase
    {
        ILolTeamLogic logic;

        public LolTeamController(ILolTeamLogic logic)
        {
            this.logic = logic;
        }


        // GET: api/<LolPlayerController>
        [HttpGet]
        public IEnumerable<LolTeam> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<LolPlayerController>/5
        [HttpGet("{id}")]
        public LolTeam Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<LolPlayerController>
        [HttpPost]
        public void Create([FromBody] LolTeam value)
        {
            this.logic.Create(value);
        }

        // PUT api/<LolPlayerController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] LolTeam value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<LolPlayerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

    }
}
