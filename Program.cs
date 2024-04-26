using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
