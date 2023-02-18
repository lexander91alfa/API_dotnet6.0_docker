using System.Text.Json;

namespace Alfa.Filmes.Api.Middleware;

public class ErroResponseMiddleware
{
    private readonly RequestDelegate next;

    public ErroResponseMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        var erroResponse = new ErroResponse();

        erroResponse.addError(e.Message);

        context.Response.StatusCode = 500;

        var result = JsonSerializer.Serialize(erroResponse.GetErrors());
        context.Response.ContentType = "application/json";


        return context.Response.WriteAsync(result);
    }
}

public static class ErrorMiddleware
{
    public static void UseErrorMiddleware(this WebApplication app) => app.UseMiddleware<ErroResponseMiddleware>();
}

