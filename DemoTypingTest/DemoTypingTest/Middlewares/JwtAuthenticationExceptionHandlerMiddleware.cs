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
        catch (SecurityTokenExpiredException)
        {
            context.Response.Headers.Add("Token-Expired", "true");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Token has expired.");
        }
        catch (SecurityTokenInvalidSignatureException)
        {
            context.Response.Headers.Add("Token-SignatureInvalid", "true");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Token signature is invalid.");
        }
        catch (Exception)
        {
            context.Response.Headers.Add("Token-Error", "true");
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}
