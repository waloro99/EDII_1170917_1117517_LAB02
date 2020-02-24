using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LAB02_ED2.Class;

namespace LAB02_ED2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
  

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }

        [HttpPost]
        public void Post([FromBody]Soda newSoda)
        {

        }
    }
}
