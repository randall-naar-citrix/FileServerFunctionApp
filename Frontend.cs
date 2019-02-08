#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    var stream = new FileStream(@"D:\home\site\wwwroot\HttpTrigger1\index.html", FileMode.Open);
    return new OkObjectResult(stream);
}
