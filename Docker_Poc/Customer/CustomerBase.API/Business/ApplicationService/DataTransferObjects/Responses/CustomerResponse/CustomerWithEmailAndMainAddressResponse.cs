using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
public sealed record CustomerWithEmailAndMainAddressResponse
{
    public int CustomerId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required AddressCustomerResponse Address { get; set; }
}
