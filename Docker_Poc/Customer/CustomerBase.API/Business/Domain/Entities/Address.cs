using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.Domain.Entities;
public sealed class Address
{
    public int AddressId { get; set; }
    public EAddressType AddressType { get; set; }
    public required string Localization { get; set; }
    public required string District { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Number { get; set; }
    public required string ZipCode { get; set; }
    public string? Complement { get; set; }
    public required string Country { get; set; }

    public int CustomerId { get; set; }
}
