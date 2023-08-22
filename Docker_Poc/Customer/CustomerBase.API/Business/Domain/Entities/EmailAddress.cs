using CustomerBase.API.Business.Domain.Enums;

namespace CustomerBase.API.Business.Domain.Entities;
public sealed class EmailAddress
{
    public int EmailAddressId { get; set; }
    public EEmailType EmailType { get; set; }
    public required string Email { get; set; }

    public int CustomerId { get; set; }
}
