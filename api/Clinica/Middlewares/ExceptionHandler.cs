using System.Net;
using System.Security.Claims;
using System.Text.Json;
using Clinica.Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;

namespace Clinica.Middlewares;

public class ExceptionHandler
{
    #region Private Fields

    private readonly RequestDelegate next;

    #endregion Private Fields

    #region Public Constructors

    public ExceptionHandler(RequestDelegate next)
    {
        this.next = next;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task Invoke(HttpContext httpContext, ILogger<ExceptionHandler> logger)
    {
        EnrichLogWithUserContext(httpContext);

        try
        {
            await this.next.Invoke(httpContext);
        }
        catch (NotAuthorizedException e)
        {
            await HandleException(httpContext, e, logger, (int)HttpStatusCode.Unauthorized);
        }
        catch (BadRequestException e)
        {
            await HandleException(httpContext, e, logger, (int)HttpStatusCode.BadRequest);
        }
        catch (NotFoundException e)
        {
            await HandleException(httpContext, e, logger, (int)HttpStatusCode.NotFound);
        }
        catch (ValidationException e)
        {
            await HandleValidationException(httpContext, e);
        }
        catch (Exception e)
        {
            await HandleException(httpContext, e, logger, (int)HttpStatusCode.InternalServerError);
        }
    }

    #endregion Public Methods

    #region Private Methods

    private static async Task HandleException(HttpContext httpContext, Exception e,
        ILogger<ExceptionHandler> logger, int statusCode)
    {
        var correlationId = Guid.NewGuid();
        LogContext.PushProperty("CorrelationId", correlationId);

        logger.LogError(e, e.Message);

        httpContext.Response.StatusCode = statusCode;
        string message = string.Format(Constants.GenericErrorResponseTemplate, correlationId);
        if (statusCode != (int)HttpStatusCode.InternalServerError)
        {
            message = e.Message;
        }

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(message));
    }

    private void EnrichLogWithUserContext(HttpContext httpContext)
    {
        var username = httpContext.User.Identity.IsAuthenticated
            ? httpContext.User.FindFirst(ClaimTypes.Name)?.Value
            : string.Empty;

        var userId = httpContext.User.Identity.IsAuthenticated
            ? httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            : string.Empty;

        LogContext.PushProperty("Username", username);
        LogContext.PushProperty("UserId", userId);
    }

    private async Task HandleValidationException(HttpContext httpContext, Exception ex)
    {
        var exception = (ValidationException)ex;
        var errors = exception.Errors.GroupBy(x => x.PropertyName, x => x.ErrorMessage)
            .ToDictionary(x => x.Key, x => x.ToArray());
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        await httpContext.Response.WriteAsJsonAsync(new ValidationProblemDetails(errors)
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        });
    }

    #endregion Private Methods
}