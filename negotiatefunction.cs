#r "Newtonsoft.Json"
#r "D:\home\site\wwwroot\bin\Microsoft.Azure.WebJobs.Extensions.SignalRService.dll"

using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static SignalRConnectionInfo Run(HttpRequest req, ILogger log, SignalRConnectionInfo connectionInfo)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
   

    string name = req.Query["name"];
    string signalrconnection = connectionInfo.ToString();
    //const connection =  new SignalR.HubConnectionBuilder()
    //.WithUrl("Endpoint=https://michaelsignalr.service.signalr.net;AccessKey=n6AsmCaEaR9+Xbl/NRP7r+8spvENG6MSiutS9JgsmcE=;Version=1.0;")
    //.Build();

    //log.LogInformation("Connection is: " + signalrconnection);

    /* string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");*/
      return connectionInfo;
}
