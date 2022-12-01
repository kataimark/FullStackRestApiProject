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
    public class LolManagerController : ControllerBase
    {
        ILolManagerLogic ml;

        public LolManagerController(ILolManagerLogic logic)
        {
            this.ml = logic;
        }


        [HttpGet]
        public IEnumerable<LolManager> Get()
        {
            return ml.ReadAll();
        }

        [HttpGet("{id}")]
        public LolManager Get(int id)
        {
            return ml.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] LolManager value)
        {
            ml.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] LolManager value)
        {
            ml.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ml.Delete(id);
        }
    }
}
