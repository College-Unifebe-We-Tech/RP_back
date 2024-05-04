using dotenv.net;
using Microsoft.EntityFrameworkCore;

DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Migrations Database Connection
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(EnvironmentVariables.DBString));

var app = builder.Build();
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "We-Tech API V1");
    });

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MyDbContext>();
        context.Database.Migrate();
    }   

    app.UseCors(context => {
        context.AllowAnyHeader();
        context.AllowAnyMethod();
        context.AllowAnyOrigin();
    });
}

app.UseMiddleware<ExceptionHandleMiddleware>();
Routing.MapEndpoints(app);

app.Run(); 
