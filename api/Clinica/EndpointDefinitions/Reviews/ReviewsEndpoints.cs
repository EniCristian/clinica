using Clinica.Middlewares;

namespace Clinica.EndpointDefinitions.Reviews;

public static class ReviewsEndpoints
{
    public static void RegisterReviewsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var booksEndpoints = endpointRouteBuilder.MapGroup("reviews");

        booksEndpoints.MapGet(ReviewsHandlers.GetReviews);
    }
}