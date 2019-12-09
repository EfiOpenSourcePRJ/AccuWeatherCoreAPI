using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccuWeatherCoreAPI.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace AccuWeatherCoreAPI.Controllers
{

  
    [ApiController]
    public class AccuCoreAPIController : Controller
    {
        public AccuCoreAPIController(IBLManager bLManager)
        {
            BLManager = bLManager;
        }

        public IBLManager BLManager { get; }

        [Route("GetWeatherDataByCity")]
        [HttpGet]
        
        public IActionResult InGetWeatherDataByParams(int cityID )
        {
            var retData = BLManager.GetCityDataByCityID(cityID);
            return Ok(retData);
           
        }




        [Route("Test")]
        [HttpGet]

        public IActionResult Test()
        {
            var retData = BLManager.GetCityDataByCityID(1);
            return Ok(retData);
        }
    }
}