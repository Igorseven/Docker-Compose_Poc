using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
public sealed record TelephoneCustomerRegisterRequest
{
    public ETelephoneType TelephoneType { get; set; }
    public required string Ddi { get; set; }
    public string? Ddd { get; set; }
    public required string PhoneNumber { get; set; }
}
