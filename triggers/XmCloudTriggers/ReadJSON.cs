
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace XmCloudTriggers
{
    public static class ReadJSON
    {

        [Function("ReadJSON")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            string jsonString = string.Empty;
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic jObject = JObject.Parse(requestBody);
                jsonString = Convert.ToString(jObject);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Error processing request "+ ex.Message);
            }

            return new OkObjectResult(jsonString);
        }
    }
}
