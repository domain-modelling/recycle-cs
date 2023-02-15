namespace Recycle.WebAPI.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
            await _next(context);

            if (context.Request.Method == "POST")
            {
                var reader = new StreamReader(context.Request.Body);
                var body = await reader.ReadToEndAsync();
                
                logger.LogInformation(
                    "Request {method} {url} => {body}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    body);    
            }
        
    }
}