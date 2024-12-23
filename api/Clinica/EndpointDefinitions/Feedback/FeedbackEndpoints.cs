using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Feedback;

public static class FeedbackEndpoints
{
    public static void RegisterFeedbackEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("feedback");

        booksEndpoints.MapPost(FeedbackHandlers.Post);
    }
}