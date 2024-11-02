using Clinica.Application.Common.Mapping;
using Clinica.Domain.Entities;

namespace Clinica.Application.Queries.Reviews;

public class ReviewDto: IMapFrom<PatientReview>
{
    public string Message { get; set; }
    public PatientDto Patient { get; set; }
}

public class PatientDto: IMapFrom<Patient>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Job { get; set; }
}