using backend.Models;
using backend.Handlers;
using backend.Repositories;
using backend.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
    }
);

Context db = new Context();
Repository repo = new Repository(db);
Service service = new Service(repo);
Handler handler = new Handler(service, app);

app.Run();
