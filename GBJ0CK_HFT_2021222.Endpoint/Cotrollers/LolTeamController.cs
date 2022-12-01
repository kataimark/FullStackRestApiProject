using GBJ0CK_HFT_2021222.Logic;
using GBJ0CK_HFT_2021222.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GBJ0CK_HFT_2021222.Endpoint.Cotrollers
{
    [Route("[controller]")]
    [ApiController]
    public class LolTeamController : ControllerBase
    {
        ILolTeamLogic tl;

        public LolTeamController(ILolTeamLogic tl)
        {
            this.tl = tl;
        }


        [HttpGet]
        public IEnumerable<LolTeam> Get()
        {
            return tl.ReadAll();
        }

        [HttpGet("{id}")]
        public LolTeam Get(int id)
        {
            return tl.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] LolTeam value)
        {
            tl.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] LolTeam value)
        {
            tl.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tl.Delete(id);
        }
    }
}
