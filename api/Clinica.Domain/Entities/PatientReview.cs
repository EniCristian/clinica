using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class PatientReview: BaseEntity
{
    public Guid PatientId { get; set; }
    public virtual Patient Patient { get; set; }
    public string Message { get; set; }
}