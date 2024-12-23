using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Patient : BaseEntity
{
    public required string FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public virtual IEnumerable<PatientReview> PatientReviews { get; set; }
}