public class ExceptionHandleMiddleware
 {
    private readonly RequestDelegate _next;

    public ExceptionHandleMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ArgumentException exception)
        {
            await Results.BadRequest(exception.Message).ExecuteAsync(httpContext);
        }
        catch (Exception exception)
        {
            await Results.Problem(exception.Message).ExecuteAsync(httpContext);
        }
    }
 }
