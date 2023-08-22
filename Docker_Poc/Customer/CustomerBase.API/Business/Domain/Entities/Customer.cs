namespace CustomerBase.API.Business.Domain.Entities;
public sealed class Customer
{
    public int CustomerId { get; set; }
    public required string FullName { get; set; }

    public required List<Address> Addresses { get; set; }
    public required List<Telephone> Telephones { get; set; }
    public required List<EmailAddress> Emails { get; set; }
}
