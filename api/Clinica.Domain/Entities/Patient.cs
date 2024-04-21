using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageUrl { get; set; }
    public string Job { get; set; }

    public virtual IEnumerable<PatientReview> PatientReviews { get; set; }
}