using ECommerce.API;
using ECommerce.Application.Interfaces;
using ECommerce.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Gọi đến Startup.cs
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
