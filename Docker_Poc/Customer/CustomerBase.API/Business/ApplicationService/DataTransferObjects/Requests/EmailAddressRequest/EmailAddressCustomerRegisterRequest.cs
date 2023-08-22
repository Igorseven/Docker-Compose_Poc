using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
public sealed record EmailAddressCustomerRegisterRequest
{
    public EEmailType EmailType { get; set; }
    public required string Email { get; set; }
}
