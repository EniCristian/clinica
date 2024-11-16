using Clinica.EndpointDefinitions.Appointments;
using Clinica.EndpointDefinitions.ContactInformation;
using Clinica.EndpointDefinitions.Feedback;
using Clinica.EndpointDefinitions.Medics;
using Clinica.EndpointDefinitions.Reviews;
using Clinica.EndpointDefinitions.Specialities;
using Clinica.EndpointDefinitions.Translations;
using Clinica.EndpointDefinitions.Users;

namespace Clinica.EndpointDefinitions;

internal static  class EndpointDefinition 
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.RegisterUsersEndpoints();
        app.RegisterTranslationsEndpoints();
        app.RegisterContactInformationEndpoints();
        app.RegisterMedicsEndpoints();
        app.RegisterAppointmentEndpoints();
        app.RegisterFeedbackEndpoints();
        app.RegisterReviewsEndpoints();
        app.RegisterSpecialitiesEndpoints();
    }
}