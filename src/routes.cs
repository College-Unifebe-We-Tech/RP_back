public static class Routing {
  public static void MapEndpoints(this WebApplication app) {
    HealthController healthController = new();

    app.MapGet("/", () => "Hello World!");
    app.MapGet("/health", (HttpContext context) => healthController.Check(context));
  }
}
