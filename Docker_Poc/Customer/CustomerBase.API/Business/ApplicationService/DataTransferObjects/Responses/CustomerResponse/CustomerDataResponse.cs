namespace CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
public sealed record CustomerDataResponse
{
    public int CustomerId { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }

}
