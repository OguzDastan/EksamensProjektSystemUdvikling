using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherStationExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDatasController : ControllerBase
    {
        // GET: api/WeatherDatas
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WeatherDatas/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/WeatherDatas
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/WeatherDatas/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
