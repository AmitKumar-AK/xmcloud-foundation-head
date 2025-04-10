using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace XmCloudTriggers
{
    /// <summary>
    /// This class contains a function that reads a JSON object from the request body and returns it as a string.
    /// A webhook is a method for a service to give other applications real-time information.
    /// Webhooks are sometimes called reverse APIs or HTTP callbacks.
    /// Experience Edge webhooks have two execution modes: OnEnd and OnUpdate
    /// </summary>
    public static class ReadJSON
    {
        /// <summary>
        /// This method is triggered by an HTTP request and reads a JSON object from the request body and sends it back as a string.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
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
