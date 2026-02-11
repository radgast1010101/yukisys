using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

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
