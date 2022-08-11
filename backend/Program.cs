using backend.Models;
using backend.Handlers;
using backend.Repositories;
using backend.Services;

Context db = new Context();
Repository repo = new Repository(db);
Service service = new Service(repo);
Handler handler = new Handler(service);

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run();
