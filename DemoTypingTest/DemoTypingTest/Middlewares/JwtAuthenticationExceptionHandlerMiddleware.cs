using Microsoft.IdentityModel.Tokens;
using System.Net;

public class JwtAuthenticationExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public JwtAuthenticationExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (SecurityTokenException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Invalid token.");
        }
    }
}
