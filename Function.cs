using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace azfSerilog
{
    public class Function
    {
        [FunctionName("GetKO")]
        public async Task<IActionResult> GetKo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogWarning("Enter in GetKo");
            try
            {
                var str = string.Empty;
                var gettingError = str[100];
                return new OkObjectResult("OK");
            }
            catch (Exception ex)
            {
                log.LogError("Error:", ex);
                return new BadRequestResult();
            }
        }

        [FunctionName("GetOK")]
        public async Task<IActionResult> GetOk(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Enter in GetOk");
            return new OkObjectResult("OK");
        }
    }
}