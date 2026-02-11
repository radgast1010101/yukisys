using Microsoft.AspNetCore.Mvc;
using VbBusinessLogic2;
using VbBusinessLogic2.MyVbCode;

var builder = WebApplication.CreateBuilder(args);

// CONFIG, SERVER
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.Production.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var app = builder.Build();

app.MapGet("/", () => "Y.U.K.I.SYS - YOURU UTTARAMAN KAIJU INFORMATION SYSTEM");

// add simple todo api
var todos = new List<string>();
app.MapGet("/todos", () => todos);
app.MapPost("/todos", ([FromBody] TodoItem item) =>
{
    todos.Add(item.Task);
    return Results.Created($"/todos/{todos.Count - 1}", item.Task);
});

// sample vb.net api
// e.g. url with param, http://localhost:5175/add?a=1&b=2
app.MapGet("/add", (int a, int b) => {
    var calc1 = new Class1().Add(a, b);
    var calc2 = new Calculator().Add(a, b);
    return calc1 + calc2;
});

app.Run();

public record TodoItem(string Task);
