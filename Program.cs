using dotenv.net;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

DotEnv.Load();

app.MapGet("/", () => "Hello World!");

HealthController healthController = new HealthController(); // create the controller
app.MapGet("/health", (HttpContext context) => healthController.Check(context)); // bind a route to a controller function.

app.Run();
