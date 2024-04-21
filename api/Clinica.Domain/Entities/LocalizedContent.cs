using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class LocalizedContent: BaseEntity
{
    public Guid ParentId { get; set; }
    public string Locale { get; set; }
    public string Value { get; set; }
}