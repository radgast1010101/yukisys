using Microsoft.AspNetCore.Mvc;

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

app.Run();

public record TodoItem(string Task);
