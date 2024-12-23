using Clinica.Application.Common.Mapping;
using Clinica.Domain.Entities;

namespace Clinica.Application.Reviews;

public class ReviewDto: IMapFrom<PatientReview>
{
    public string Message { get; set; }
    public PatientDto Patient { get; set; }
}

public class PatientDto: IMapFrom<Patient>
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}