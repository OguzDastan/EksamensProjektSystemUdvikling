﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherStationExam.Managers;
using WeatherLibrary;

namespace WeatherStationExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDatasController : ControllerBase
    {

        private WeatherDatasManager wm = new WeatherDatasManager();
        

        // GET: api/WeatherDatas
        [HttpGet]
        public IEnumerable<WeatherData> Get()
        {
            return wm.Get();
        }

        // GET: api/WeatherDatas/5
        [HttpGet("{id}", Name = "Get")]
        public WeatherData Get(int id)
        {
            return wm.Get(id);
        }

        // POST: api/WeatherDatas
        [HttpPost]
        public void Post([FromBody] WeatherData value)
        {
            wm.Post(value);
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
