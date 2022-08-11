using backend.Models;

Context db = new Context();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run();
