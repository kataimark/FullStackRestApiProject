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
    public class LolManagerController : ControllerBase
    {
        ILolManagerLogic logic;

        public LolManagerController(ILolManagerLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] LolManager value)
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
