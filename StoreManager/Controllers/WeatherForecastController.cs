using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;
        public WeatherForecastController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            
            return new string[] { "value1", "value2" };
        }
    }
}
