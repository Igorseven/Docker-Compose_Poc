using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.TelephoneResponse;
public sealed record TelephoneCustomerResponse
{
    public int TelephoneId { get; set; }
    public ETelephoneType TelephoneType { get; set; }
    public required string Ddi { get; set; }
    public string? Ddd { get; set; }
    public required string PhoneNumber { get; set; }
}
