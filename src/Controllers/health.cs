public class HealthController {
    private readonly HealthService _service; // the controller will only get information from the request and give a answer, all the businnes logic must be in a service.

    public HealthController() {
        _service = new HealthService();
    }

    public async void Check(HttpContext context) {
        string result = _service.Check();

        await context.Response.WriteAsync(result); // set the value to return to front end.
    }
}