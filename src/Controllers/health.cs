public class HealthController {
    private readonly HealthService _service;

    public HealthController() {
        _service = new HealthService();
    }

    // Change the return type to Task<IResult>
    public async Task<IResult> Check() {
        Health health = await _service.Check();
        return Results.Json(health, statusCode: StatusCodes.Status200OK);
    }
}