using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class Feedback: BaseEntity
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Subject { get; set; }
    public required string Message { get; set; }
    public required DateTime Date { get; set; }
    public bool IsDisplayable { get; set; }
}