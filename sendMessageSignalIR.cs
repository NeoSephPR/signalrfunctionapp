#r "Newtonsoft.Json"
#r "D:\home\site\wwwroot\bin\Microsoft.Azure.WebJobs.Extensions.SignalRService.dll"

using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log, IAsyncCollector<SignalRMessage> signalRMessages)
{
    

    string name = req.Query["name"];
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

     log.LogInformation($"Current Name is: {name}");

      await signalRMessages.AddAsync(
        new SignalRMessage
        {
            Target = "newMessage",
            Arguments = new [] {name}
        });
       
    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
     

     
}

 public class test : Hub
    {
        public void newMessage(string name)
        {
            Clients.All.SendAsync("newMessage", name);
        }

        
    }
