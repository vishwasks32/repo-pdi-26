namespace KiranaAppV1.API.Middleware;

using KiranaAppV1.Core.DTOs.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception ocures: {Message}", exception.Message);

        // We will set proper status code
        var StatusCode = exception switch
        {
            InvalidOperationException => (int)HttpStatusCode.BadRequest,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        httpContext.Response.StatusCode = StatusCode;

        // Creating Standard Response
        var response = new ApiResponse<object?>(false, exception.Message, null, new List<string>{exception.Message});

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}