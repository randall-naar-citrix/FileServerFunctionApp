#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public class Student{
    [JsonProperty(PropertyName = "student_id")]
    public int _studentId {get; set;}
    [JsonProperty(PropertyName = "first_name")]
    public string _firstName {get; set;}
    [JsonProperty(PropertyName = "last_name")]
    public string _lastName {get; set;}
}

public static List<Student> students = new List<Student>();
public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    var reqIsPost = string.Equals(req.Method, "post", StringComparison.OrdinalIgnoreCase);
    string body = "";

    if(!reqIsPost)
    {
        return new OkObjectResult(JsonConvert.SerializeObject(students));
    }

    var sr = new StreamReader(req.Body);
    body = sr.ReadToEnd();
    log.LogInformation(body);
    var student = JsonConvert.DeserializeObject<Student>(body);
    students.Add(student);
    return new OkObjectResult(body);    
}
