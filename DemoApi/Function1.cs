using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoApi
{
    public static class Function1
    {
        [FunctionName("GetName")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<WeatherForecast> weathers = new List<WeatherForecast>();
            weathers.Add(new WeatherForecast()
            {
                Date = DateTime.Now,
                Summary = "test",
                TemperatureC = 20
            });
            weathers.Add(new WeatherForecast()
            {
                Date = DateTime.Now.AddHours(-1),
                Summary = "test 2",
                TemperatureC = 25
            });

            return new OkObjectResult(weathers);
        }
    }
}
