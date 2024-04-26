using dotenv.net;
using Microsoft.EntityFrameworkCore;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

// Migrations Database Connection
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(EnvironmentVariables.DBString));
var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

DotEnv.Load();

app.MapGet("/", () => "Hello World!");

HealthController healthController = new HealthController(); // create the controller
app.MapGet("/health", (HttpContext context) => healthController.Check(context)); // bind a route to a controller function.

app.Run();
