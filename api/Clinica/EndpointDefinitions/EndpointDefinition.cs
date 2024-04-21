using Clinica.EndpointDefinitions.ContactInformation;
using Clinica.EndpointDefinitions.Medics;
using Clinica.EndpointDefinitions.Reviews;
using Clinica.EndpointDefinitions.Translations;

namespace Clinica.EndpointDefinitions;

internal static  class EndpointDefinition 
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.RegisterBookStoreEndpoints();
        app.RegisterContactInformationEndpoints();
        app.RegisterMedicsEndpoints();
        app.RegisterReviewsEndpoints();
    }
}