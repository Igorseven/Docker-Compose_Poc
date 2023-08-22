using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
public sealed record CustomerRegisterRequest
{
    public required string FullName { get; set; }

    public required List<AddressCustomerRegisterRequest> Addresses { get; set; }
    public required List<EmailAddressCustomerRegisterRequest> Emails { get; set; }
    public required List<TelephoneCustomerRegisterRequest> Phones { get; set; }
}
