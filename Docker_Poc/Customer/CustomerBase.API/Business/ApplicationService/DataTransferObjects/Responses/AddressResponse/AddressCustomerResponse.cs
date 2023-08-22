using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
public sealed record AddressCustomerResponse
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
}
