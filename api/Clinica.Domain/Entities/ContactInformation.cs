using Clinica.Domain.Common;

namespace Clinica.Domain.Entities;

public class ContactInformation : BaseEntity
{
    public Guid AddressId { get; set; }
    public virtual Address Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Schedule { get; set; }
    public string Email { get; set; }
}