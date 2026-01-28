namespace Inventory.Backend.Api.src.Middleware;

public class FailureHandling
{
    private readonly RequestDelegate _next;
    private readonly Random _random = new();

    public FailureHandling(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (_random.Next(1, 101) <= 10)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new
            {
                message = "10% Simulated Failure, occurring..."
            });
            return;
        }
        await _next(context);
    }
}
