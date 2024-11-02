using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Feedback;

public static class FeedbackEndpoints
{
    public static void RegisterFeedbackEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("api/feedback");

        booksEndpoints.MapPost(FeedbackHandlers.Post);
    }
}