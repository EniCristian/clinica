using Clinica.Application.Common.Mapping;
using Clinica.Domain.Entities;

namespace Clinica.Application.Queries.ContactInformations;

public class ContactInformationDto: IMapFrom<Domain.Entities.ContactInformation>
{
    public string PhoneNumber { get; set; }
    public string Schedule { get; set; }
    public string Email { get; set; }
    public AddressDto Address { get; set; }
}
public class AddressDto: IMapFrom<Address>
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}