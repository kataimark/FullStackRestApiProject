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
    public class LolPlayerController : ControllerBase
    {
        ILolPlayerLogic pl;

        public LolPlayerController(ILolPlayerLogic logic)
        {
            this.pl = logic;
        }


        // GET: LolPlayer
        [HttpGet]
        public IEnumerable<LolPlayer> Get()
        {
            return pl.ReadAll();
        }

        // GET LolPlayer/5
        [HttpGet("{id}")]
        public LolPlayer Get(int id)
        {
            return pl.Read(id);
        }

        // POST LolPlayer
        [HttpPost]
        public void Post([FromBody] LolPlayer value)
        {
            pl.Create(value);
        }

        // PUT LolPlayer/5
        [HttpPut]
        public void Put([FromBody] LolPlayer value)
        {
            pl.Update(value);
        }

        // DELETE LolPlayer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
