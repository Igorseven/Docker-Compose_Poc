using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.EmailAddressResponse;
public sealed record EmailAddressCustomerResponse
{
    public int EmailAddressId { get; set; }
    public EEmailType EmailType { get; set; }
    public required string Email { get; set; }
}
